#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Spanish Verb Conjugation Corrector - Fixed Version
Corrects and adds missing subjunctive forms to Spanish verb JSON files
"""

import json
import os
import re
from typing import Dict, List, Tuple, Optional

class SpanishVerbCorrector:
    def __init__(self):
        self.verb_directory = r"C:\temp\Taspa\TASPA\wwwroot\json\spanish\verbs"
        self.processed_count = 0
        self.corrected_count = 0
        self.errors = []
        self.common_errors = {
            'missing_subjunctive': 0,
            'formatting_issues': 0,
            'translation_format_issues': 0,
            'conjugation_errors': 0,
            'imperfect_subjunctive_fixed': 0
        }
        
        # Common irregular verbs and their patterns
        self.irregular_patterns = {
            'ser': {
                'present_subj': ['sea', 'seas', 'sea', 'seamos', 'seáis', 'sean'],
                'imperfect_subj': ['fuera', 'fueras', 'fuera', 'fuéramos', 'fuerais', 'fueran']
            },
            'estar': {
                'present_subj': ['esté', 'estés', 'esté', 'estemos', 'estéis', 'estén'],
                'imperfect_subj': ['estuviera', 'estuvieras', 'estuviera', 'estuviéramos', 'estuvierais', 'estuvieran']
            },
            'tener': {
                'present_subj': ['tenga', 'tengas', 'tenga', 'tengamos', 'tengáis', 'tengan'],
                'imperfect_subj': ['tuviera', 'tuvieras', 'tuviera', 'tuviéramos', 'tuvierais', 'tuvieran']
            },
            'hacer': {
                'present_subj': ['haga', 'hagas', 'haga', 'hagamos', 'hagáis', 'hagan'],
                'imperfect_subj': ['hiciera', 'hicieras', 'hiciera', 'hiciéramos', 'hicierais', 'hicieran']
            },
            'ir': {
                'present_subj': ['vaya', 'vayas', 'vaya', 'vayamos', 'vayáis', 'vayan'],
                'imperfect_subj': ['fuera', 'fueras', 'fuera', 'fuéramos', 'fuerais', 'fueran']
            },
            'dar': {
                'present_subj': ['dé', 'des', 'dé', 'demos', 'deis', 'den'],
                'imperfect_subj': ['diera', 'dieras', 'diera', 'diéramos', 'dierais', 'dieran']
            },
            'saber': {
                'present_subj': ['sepa', 'sepas', 'sepa', 'sepamos', 'sepáis', 'sepan'],
                'imperfect_subj': ['supiera', 'supieras', 'supiera', 'supiéramos', 'supierais', 'supieran']
            },
            'poder': {
                'present_subj': ['pueda', 'puedas', 'pueda', 'podamos', 'podáis', 'puedan'],
                'imperfect_subj': ['pudiera', 'pudieras', 'pudiera', 'pudiéramos', 'pudierais', 'pudieran']
            },
            'querer': {
                'present_subj': ['quiera', 'quieras', 'quiera', 'queramos', 'queráis', 'quieran'],
                'imperfect_subj': ['quisiera', 'quisieras', 'quisiera', 'quisiéramos', 'quisierais', 'quisieran']
            },
            'venir': {
                'present_subj': ['venga', 'vengas', 'venga', 'vengamos', 'vengáis', 'vengan'],
                'imperfect_subj': ['viniera', 'vinieras', 'viniera', 'viniéramos', 'vinierais', 'vinieran']
            },
            'decir': {
                'present_subj': ['diga', 'digas', 'diga', 'digamos', 'digáis', 'digan'],
                'imperfect_subj': ['dijera', 'dijeras', 'dijera', 'dijéramos', 'dijerais', 'dijeran']
            },
            'poner': {
                'present_subj': ['ponga', 'pongas', 'ponga', 'pongamos', 'pongáis', 'pongan'],
                'imperfect_subj': ['pusiera', 'pusieras', 'pusiera', 'pusiéramos', 'pusierais', 'pusieran']
            },
            'salir': {
                'present_subj': ['salga', 'salgas', 'salga', 'salgamos', 'salgáis', 'salgan'],
                'imperfect_subj': ['saliera', 'salieras', 'saliera', 'saliéramos', 'salierais', 'salieran']
            },
            'ver': {
                'present_subj': ['vea', 'veas', 'vea', 'veamos', 'veáis', 'vean'],
                'imperfect_subj': ['viera', 'vieras', 'viera', 'viéramos', 'vierais', 'vieran']
            },
            'haber': {
                'present_subj': ['haya', 'hayas', 'haya', 'hayamos', 'hayáis', 'hayan'],
                'imperfect_subj': ['hubiera', 'hubieras', 'hubiera', 'hubiéramos', 'hubierais', 'hubieran']
            }
        }

    def generate_regular_subjunctive(self, verb_data: Dict) -> Dict:
        """Generate regular subjunctive forms with correct imperfect subjunctive"""
        infinitive = verb_data.get('Name', '')
        if not infinitive:
            return {}
            
        present_forms = verb_data.get('Indicative', {}).get('PresentTense', {})
        preterite_forms = verb_data.get('Indicative', {}).get('Pretérito', {})
        
        # Get yo form for present subjunctive stem
        yo_present = present_forms.get('Yo', '')
        if not yo_present:
            return {}
            
        # Present subjunctive stem (remove -o from yo form)
        pres_subj_stem = yo_present[:-1] if yo_present.endswith('o') else yo_present[:-2]
        
        # Imperfect subjunctive stem (from third person plural preterite)
        ellos_preterite = preterite_forms.get('EllosEllasUstedes', '')
        if ellos_preterite.endswith('ron'):
            imp_subj_stem = ellos_preterite[:-3]  # Remove -ron
        else:
            # Fallback for irregular patterns
            if infinitive.endswith('ar'):
                imp_subj_stem = infinitive[:-2] + 'a'
            else:
                imp_subj_stem = infinitive[:-2] + 'ie'
        
        # Determine endings based on verb type
        if infinitive.endswith('ar'):
            pres_endings = ['e', 'es', 'e', 'emos', 'éis', 'en']
        else:  # -er and -ir verbs
            pres_endings = ['a', 'as', 'a', 'amos', 'áis', 'an']
        
        # Imperfect subjunctive endings (same for all verbs)
        imp_endings = ['ra', 'ras', 'ra', 'ramos', 'rais', 'ran']
        
        persons = ['Yo', 'Tu', 'ElEllaUsted', 'Nosotros', 'Vosotros', 'EllosEllasUstedes']
        
        return {
            'PresentSubjunctive': {
                person: pres_subj_stem + ending 
                for person, ending in zip(persons, pres_endings)
            },
            'ImperfectSubjunctive': {
                person: imp_subj_stem + ending 
                for person, ending in zip(persons, imp_endings)
            }
        }

    def generate_subjunctive_forms(self, verb_data: Dict) -> Dict:
        """Generate subjunctive forms for a verb"""
        infinitive = verb_data.get('Name', '')
        
        if not infinitive:
            return {}
            
        # Check for irregular verbs first
        if infinitive in self.irregular_patterns:
            pattern = self.irregular_patterns[infinitive]
            return {
                'PresentSubjunctive': {
                    'Yo': pattern['present_subj'][0],
                    'Tu': pattern['present_subj'][1],
                    'ElEllaUsted': pattern['present_subj'][2],
                    'Nosotros': pattern['present_subj'][3],
                    'Vosotros': pattern['present_subj'][4],
                    'EllosEllasUstedes': pattern['present_subj'][5]
                },
                'ImperfectSubjunctive': {
                    'Yo': pattern['imperfect_subj'][0],
                    'Tu': pattern['imperfect_subj'][1],
                    'ElEllaUsted': pattern['imperfect_subj'][2],
                    'Nosotros': pattern['imperfect_subj'][3],
                    'Vosotros': pattern['imperfect_subj'][4],
                    'EllosEllasUstedes': pattern['imperfect_subj'][5]
                }
            }
        
        # For regular verbs and stem-changing verbs
        return self.generate_regular_subjunctive(verb_data)

    def fix_existing_subjunctive_errors(self, verb_data: Dict) -> List[str]:
        """Fix errors in existing subjunctive forms"""
        corrections = []
        subjunctive = verb_data.get('Subjunctive')
        
        if not subjunctive or not isinstance(subjunctive, dict):
            return corrections
        
        # Check for imperfect subjunctive errors (ending with 'a' instead of 'ra')
        imp_subj = subjunctive.get('ImperfectSubjunctive', {})
        if isinstance(imp_subj, dict):
            needs_fixing = False
            for person, form in imp_subj.items():
                if isinstance(form, str) and form.endswith('aa'):
                    needs_fixing = True
                    break
            
            if needs_fixing:
                # Regenerate correct forms
                infinitive = verb_data.get('Name', '')
                if infinitive in self.irregular_patterns:
                    pattern = self.irregular_patterns[infinitive]
                    corrected_forms = {
                        'Yo': pattern['imperfect_subj'][0],
                        'Tu': pattern['imperfect_subj'][1],
                        'ElEllaUsted': pattern['imperfect_subj'][2],
                        'Nosotros': pattern['imperfect_subj'][3],
                        'Vosotros': pattern['imperfect_subj'][4],
                        'EllosEllasUstedes': pattern['imperfect_subj'][5]
                    }
                else:
                    # Generate regular forms
                    new_subjunctive = self.generate_regular_subjunctive(verb_data)
                    corrected_forms = new_subjunctive.get('ImperfectSubjunctive', {})
                
                if corrected_forms:
                    verb_data['Subjunctive']['ImperfectSubjunctive'] = corrected_forms
                    corrections.append("Fixed imperfect subjunctive conjugations")
                    self.common_errors['imperfect_subjunctive_fixed'] += 1
        
        return corrections

    def clean_translation_format(self, text: str) -> Tuple[str, str]:
        """Clean translation format and extract translation"""
        if '&translation=' in text:
            parts = text.split('&translation=')
            return parts[0], parts[1] if len(parts) > 1 else ''
        return text, ''

    def validate_conjugations(self, verb_data: Dict) -> List[str]:
        """Validate conjugations for common errors"""
        errors = []
        infinitive = verb_data.get('Name', '')
        
        if not infinitive:
            errors.append("Missing infinitive name")
            return errors
        
        # Check for required sections
        if 'Indicative' not in verb_data:
            errors.append("Missing Indicative section")
            return errors
            
        indicative = verb_data['Indicative']
        required_tenses = ['PresentTense', 'Pretérito', 'Imperfect', 'Conditional', 'Future']
        
        for tense in required_tenses:
            if tense not in indicative:
                errors.append(f"Missing {tense}")
                continue
                
            tense_forms = indicative[tense]
            if not isinstance(tense_forms, dict):
                errors.append(f"Invalid format for {tense}")
                continue
                
            required_persons = ['Yo', 'Tu', 'ElEllaUsted', 'Nosotros', 'Vosotros', 'EllosEllasUstedes']
            
            for person in required_persons:
                if person not in tense_forms or not tense_forms[person]:
                    errors.append(f"Missing {person} form in {tense}")
        
        return errors

    def process_verb_file(self, filepath: str) -> Tuple[bool, List[str]]:
        """Process a single verb file"""
        try:
            with open(filepath, 'r', encoding='utf-8') as f:
                content = f.read()
            
            # Parse JSON
            verb_data = json.loads(content)
            original_content = content  # Keep original for comparison
            
            corrections_made = []
            
            # Clean translation format
            if 'PresentParticiple' in verb_data:
                clean_pp, trans_pp = self.clean_translation_format(verb_data['PresentParticiple'])
                if trans_pp:
                    verb_data['PresentParticiple'] = clean_pp
                    if 'PresentParticipleTranslation' not in verb_data:
                        verb_data['PresentParticipleTranslation'] = trans_pp
                    corrections_made.append("Fixed PresentParticiple translation format")
                    self.common_errors['translation_format_issues'] += 1
            
            if 'PastParticiple' in verb_data:
                clean_pp, trans_pp = self.clean_translation_format(verb_data['PastParticiple'])
                if trans_pp:
                    verb_data['PastParticiple'] = clean_pp
                    if 'PastParticipleTranslation' not in verb_data:
                        verb_data['PastParticipleTranslation'] = trans_pp
                    corrections_made.append("Fixed PastParticiple translation format")
                    self.common_errors['translation_format_issues'] += 1
            
            # Validate conjugations
            conjugation_errors = self.validate_conjugations(verb_data)
            if conjugation_errors:
                corrections_made.extend([f"Validation error: {error}" for error in conjugation_errors])
                self.common_errors['conjugation_errors'] += len(conjugation_errors)
            
            # Fix existing subjunctive errors
            subjunctive_fixes = self.fix_existing_subjunctive_errors(verb_data)
            corrections_made.extend(subjunctive_fixes)
            
            # Add subjunctive forms if missing
            if verb_data.get('Subjunctive') is None:
                subjunctive_forms = self.generate_subjunctive_forms(verb_data)
                if subjunctive_forms:
                    verb_data['Subjunctive'] = subjunctive_forms
                    corrections_made.append("Added missing subjunctive forms")
                    self.common_errors['missing_subjunctive'] += 1
            
            # Check if any corrections were made
            if corrections_made:
                # Write back the corrected file with proper formatting
                with open(filepath, 'w', encoding='utf-8') as f:
                    json.dump(verb_data, f, ensure_ascii=False, indent=2)
                    f.write('\n')  # Add newline at end
                self.common_errors['formatting_issues'] += 1
                return True, corrections_made
            
            return False, []
            
        except json.JSONDecodeError as e:
            error_msg = f"JSON parsing error: {str(e)}"
            self.errors.append((filepath, error_msg))
            return False, [error_msg]
        except Exception as e:
            error_msg = f"Processing error: {str(e)}"
            self.errors.append((filepath, error_msg))
            return False, [error_msg]

    def process_all_files(self):
        """Process all verb files in the directory"""
        if not os.path.exists(self.verb_directory):
            print(f"Error: Directory {self.verb_directory} does not exist")
            return
            
        json_files = [f for f in os.listdir(self.verb_directory) if f.endswith('.json')]
        json_files.sort()  # Process alphabetically
        
        print(f"Re-processing {len(json_files)} verb files to fix imperfect subjunctive errors...")
        
        for i, filename in enumerate(json_files, 1):
            filepath = os.path.join(self.verb_directory, filename)
            print(f"Processing {i:3d}/{len(json_files)}: {filename}", end=" ... ")
            
            corrected, corrections = self.process_verb_file(filepath)
            self.processed_count += 1
            
            if corrected:
                self.corrected_count += 1
                print(f"CORRECTED ({len(corrections)} changes)")
                if corrections:
                    for correction in corrections[:2]:  # Show first 2 corrections
                        print(f"    - {correction}")
                    if len(corrections) > 2:
                        print(f"    ... and {len(corrections) - 2} more")
            else:
                print("OK")
        
        self.print_summary()

    def print_summary(self):
        """Print processing summary"""
        print("\n" + "="*80)
        print("PROCESSING SUMMARY - FIXED VERSION")
        print("="*80)
        print(f"Files processed: {self.processed_count}")
        print(f"Files corrected: {self.corrected_count}")
        print(f"Files with errors: {len(self.errors)}")
        
        print("\nCommon error types found:")
        for error_type, count in self.common_errors.items():
            if count > 0:
                print(f"  {error_type.replace('_', ' ').title()}: {count}")
        
        if self.errors:
            print("\nFiles with processing errors:")
            for filepath, error in self.errors[:10]:  # Show first 10 errors
                filename = os.path.basename(filepath)
                print(f"  {filename}: {error}")
            if len(self.errors) > 10:
                print(f"  ... and {len(self.errors) - 10} more errors")
        
        print("\nProcessing completed successfully!")

if __name__ == "__main__":
    corrector = SpanishVerbCorrector()
    corrector.process_all_files()