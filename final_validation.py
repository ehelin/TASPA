#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Final Validation and Report for Spanish Verb Conjugations
"""

import json
import os
from typing import Dict, List, Tuple

class FinalValidator:
    def __init__(self):
        self.verb_directory = r"C:\temp\Taspa\TASPA\wwwroot\json\spanish\verbs"
        self.total_files = 0
        self.properly_corrected = 0
        self.still_have_errors = 0
        self.missing_data = 0
        self.problematic_files = []
        self.validation_results = {
            'imperfect_subjunctive_correct': 0,
            'imperfect_subjunctive_errors': 0,
            'missing_subjunctive': 0,
            'complete_conjugations': 0,
            'translation_format_correct': 0
        }

    def validate_imperfect_subjunctive(self, verb_data: Dict, filename: str) -> List[str]:
        """Validate imperfect subjunctive forms"""
        issues = []
        subjunctive = verb_data.get('Subjunctive')
        
        if not subjunctive:
            issues.append("Missing Subjunctive section")
            return issues
        
        imp_subj = subjunctive.get('ImperfectSubjunctive')
        if not imp_subj:
            issues.append("Missing ImperfectSubjunctive")
            return issues
        
        # Check for common errors
        for person, form in imp_subj.items():
            if isinstance(form, str):
                # Check for incorrect endings like 'aa', 'ea', 'ia' instead of 'ara', 'iera', etc.
                if form.endswith('aa') or form.endswith('ea') or form.endswith('ia'):
                    issues.append(f"Incorrect imperfect subjunctive form for {person}: {form}")
                elif not (form.endswith('ra') or form.endswith('se')):
                    # Spanish imperfect subjunctive should end in -ra or -se
                    issues.append(f"Suspicious imperfect subjunctive form for {person}: {form}")
        
        if not issues:
            self.validation_results['imperfect_subjunctive_correct'] += 1
        else:
            self.validation_results['imperfect_subjunctive_errors'] += 1
        
        return issues

    def validate_completeness(self, verb_data: Dict) -> List[str]:
        """Validate completeness of conjugations"""
        issues = []
        
        # Check required top-level fields
        required_fields = ['Name', 'EnglishMeaning', 'PresentParticiple', 'PastParticiple']
        for field in required_fields:
            if field not in verb_data or not verb_data[field]:
                issues.append(f"Missing {field}")
        
        # Check Indicative section
        indicative = verb_data.get('Indicative', {})
        required_tenses = ['PresentTense', 'Pretérito', 'Imperfect', 'Conditional', 'Future']
        
        for tense in required_tenses:
            if tense not in indicative:
                issues.append(f"Missing {tense}")
                continue
            
            tense_forms = indicative[tense]
            if not isinstance(tense_forms, dict):
                issues.append(f"Invalid format for {tense}")
                continue
            
            # Count non-null forms
            non_null_forms = sum(1 for form in tense_forms.values() if form is not None)
            if non_null_forms == 0:
                issues.append(f"All forms are null in {tense}")
            elif non_null_forms < 6:
                issues.append(f"Incomplete forms in {tense} ({non_null_forms}/6 present)")
        
        # Check Subjunctive section
        subjunctive = verb_data.get('Subjunctive')
        if not subjunctive:
            issues.append("Missing Subjunctive section")
            self.validation_results['missing_subjunctive'] += 1
        elif isinstance(subjunctive, dict):
            required_subj_tenses = ['PresentSubjunctive', 'ImperfectSubjunctive']
            for tense in required_subj_tenses:
                if tense not in subjunctive:
                    issues.append(f"Missing {tense}")
        
        if not issues:
            self.validation_results['complete_conjugations'] += 1
        
        return issues

    def validate_translation_format(self, verb_data: Dict) -> List[str]:
        """Validate translation format"""
        issues = []
        
        # Check for old format with &translation=
        pp = verb_data.get('PresentParticiple', '')
        if isinstance(pp, str) and '&translation=' in pp:
            issues.append("PresentParticiple still has old translation format")
        
        pas_p = verb_data.get('PastParticiple', '')
        if isinstance(pas_p, str) and '&translation=' in pas_p:
            issues.append("PastParticiple still has old translation format")
        
        if not issues:
            self.validation_results['translation_format_correct'] += 1
        
        return issues

    def validate_file(self, filepath: str) -> Tuple[bool, List[str]]:
        """Validate a single verb file"""
        try:
            with open(filepath, 'r', encoding='utf-8') as f:
                verb_data = json.loads(f.read())
            
            all_issues = []
            
            # Run all validations
            all_issues.extend(self.validate_completeness(verb_data))
            all_issues.extend(self.validate_imperfect_subjunctive(verb_data, os.path.basename(filepath)))
            all_issues.extend(self.validate_translation_format(verb_data))
            
            return len(all_issues) == 0, all_issues
            
        except json.JSONDecodeError as e:
            return False, [f"JSON parsing error: {str(e)}"]
        except Exception as e:
            return False, [f"Processing error: {str(e)}"]

    def run_validation(self):
        """Run validation on all files"""
        if not os.path.exists(self.verb_directory):
            print(f"Error: Directory {self.verb_directory} does not exist")
            return
        
        json_files = [f for f in os.listdir(self.verb_directory) if f.endswith('.json')]
        json_files.sort()
        
        print(f"Validating {len(json_files)} verb files...")
        print("="*80)
        
        for i, filename in enumerate(json_files, 1):
            filepath = os.path.join(self.verb_directory, filename)
            is_valid, issues = self.validate_file(filepath)
            
            self.total_files += 1
            
            if is_valid:
                self.properly_corrected += 1
                print(f"{i:3d}/{len(json_files)}: {filename:<20} [OK] VALID")
            else:
                if any("null" in issue or "Missing" in issue for issue in issues):
                    self.missing_data += 1
                else:
                    self.still_have_errors += 1
                
                self.problematic_files.append((filename, issues))
                print(f"{i:3d}/{len(json_files)}: {filename:<20} [!] ISSUES ({len(issues)} problems)")
                
                # Show first few issues
                for issue in issues[:2]:
                    print(f"    - {issue}")
                if len(issues) > 2:
                    print(f"    ... and {len(issues) - 2} more")
        
        self.print_final_report()

    def print_final_report(self):
        """Print comprehensive final report"""
        print("\n" + "="*80)
        print("FINAL VALIDATION REPORT")
        print("="*80)
        
        print(f"Total files processed: {self.total_files}")
        print(f"Files with correct conjugations: {self.properly_corrected}")
        print(f"Files with missing data: {self.missing_data}")
        print(f"Files with other errors: {self.still_have_errors}")
        
        success_rate = (self.properly_corrected / self.total_files) * 100 if self.total_files > 0 else 0
        print(f"Success rate: {success_rate:.1f}%")
        
        print("\nValidation Details:")
        print(f"  Files with correct imperfect subjunctive: {self.validation_results['imperfect_subjunctive_correct']}")
        print(f"  Files with imperfect subjunctive errors: {self.validation_results['imperfect_subjunctive_errors']}")
        print(f"  Files missing subjunctive forms: {self.validation_results['missing_subjunctive']}")
        print(f"  Files with complete conjugations: {self.validation_results['complete_conjugations']}")
        print(f"  Files with correct translation format: {self.validation_results['translation_format_correct']}")
        
        if self.problematic_files:
            print(f"\nTop 10 problematic files:")
            for filename, issues in self.problematic_files[:10]:
                print(f"  {filename}:")
                for issue in issues[:2]:
                    print(f"    - {issue}")
                if len(issues) > 2:
                    print(f"    ... and {len(issues) - 2} more")
        
        print("\nSUMMARY:")
        print(f"[+] Successfully processed and corrected: {self.properly_corrected} files")
        if self.missing_data > 0:
            print(f"[!] Files with missing/incomplete data: {self.missing_data} files")
        if self.still_have_errors > 0:
            print(f"[-] Files still needing attention: {self.still_have_errors} files")
        
        print("\nThe verb correction process has been completed!")

if __name__ == "__main__":
    validator = FinalValidator()
    validator.run_validation()