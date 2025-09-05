#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Spanish Imperfect Subjunctive Accent Corrector
Fixes missing accent marks in imperfect subjunctive forms
"""

import json
import os
from typing import Dict

class AccentCorrector:
    def __init__(self):
        self.verb_directory = r"C:\temp\Taspa\TASPA\wwwroot\json\spanish\verbs"
        self.corrected_files = 0

    def add_accents_to_imperfect_subjunctive(self, verb_data: Dict) -> bool:
        """Add missing accent marks to imperfect subjunctive forms"""
        corrected = False
        subjunctive = verb_data.get('Subjunctive')
        
        if not subjunctive or not isinstance(subjunctive, dict):
            return False
        
        imp_subj = subjunctive.get('ImperfectSubjunctive')
        if not imp_subj or not isinstance(imp_subj, dict):
            return False
        
        # Fix accent marks for each form
        corrections = {
            'Yo': lambda form: form,  # No accent needed for yo form
            'Tu': lambda form: form,  # No accent needed for tu form  
            'ElEllaUsted': lambda form: form,  # No accent needed for él/ella/usted form
            'Nosotros': lambda form: self.add_accent_to_nosotros(form),  # Need accent: -áramos, -iéramos
            'Vosotros': lambda form: self.add_accent_to_vosotros(form),  # Need accent: -arais, -ierais -> -arais, -ierais
            'EllosEllasUstedes': lambda form: form  # No accent needed for ellos form
        }
        
        for person, corrector in corrections.items():
            if person in imp_subj and isinstance(imp_subj[person], str):
                original = imp_subj[person]
                corrected_form = corrector(original)
                
                if original != corrected_form:
                    imp_subj[person] = corrected_form
                    corrected = True
        
        return corrected

    def add_accent_to_nosotros(self, form: str) -> str:
        """Add accent to nosotros form of imperfect subjunctive"""
        if not form:
            return form
        
        # Pattern: ...aramos -> ...áramos, ...eramos -> ...éramos, ...iramos -> ...íramos
        if form.endswith('aramos') and 'á' not in form:
            # Find the 'a' that should have an accent
            if form.endswith('raramos'):  # Most -ar verbs: habláramos
                return form[:-6] + 'áramos'
            elif form.endswith('aramos'):
                return form[:-6] + 'áramos'
        
        elif form.endswith('eramos') and 'é' not in form:
            # -er verbs in imperfect subjunctive: comiéramos
            return form[:-6] + 'éramos'
        
        elif form.endswith('iramos') and 'í' not in form:
            # -ir verbs in imperfect subjunctive: viviéramos
            return form[:-6] + 'íramos'
        
        elif 'amos' in form and form.endswith('ramos'):
            # General pattern for other cases
            stem = form[:-5]  # Remove 'ramos'
            if stem.endswith('ra'):
                # Check if it should have accent based on verb type
                base_stem = stem[:-2]
                if len(base_stem) > 0:
                    # Add accent to the vowel before 'ramos'
                    if 'a' in stem[-2:] and 'á' not in stem[-2:]:
                        return form[:-6] + 'áramos'
                    elif 'e' in stem[-2:] and 'é' not in stem[-2:]:
                        return form[:-6] + 'éramos'
                    elif 'i' in stem[-2:] and 'í' not in stem[-2:]:
                        return form[:-6] + 'íramos'
        
        return form

    def add_accent_to_vosotros(self, form: str) -> str:
        """Add accent to vosotros form of imperfect subjunctive"""
        if not form:
            return form
        
        # Pattern: ...arais -> ...arais (no accent), ...erais -> ...erais (no accent)
        # Actually, vosotros imperfect subjunctive doesn't need accent marks
        return form

    def correct_file(self, filepath: str) -> bool:
        """Correct accent marks in a single file"""
        try:
            with open(filepath, 'r', encoding='utf-8') as f:
                verb_data = json.loads(f.read())
            
            corrected = self.add_accents_to_imperfect_subjunctive(verb_data)
            
            if corrected:
                with open(filepath, 'w', encoding='utf-8') as f:
                    json.dump(verb_data, f, ensure_ascii=False, indent=2)
                    f.write('\n')
                return True
            
            return False
            
        except Exception as e:
            print(f"Error processing {os.path.basename(filepath)}: {e}")
            return False

    def process_all_files(self):
        """Process all files to correct accent marks"""
        if not os.path.exists(self.verb_directory):
            print(f"Error: Directory {self.verb_directory} does not exist")
            return
        
        json_files = [f for f in os.listdir(self.verb_directory) if f.endswith('.json')]
        json_files.sort()
        
        print(f"Correcting accent marks in imperfect subjunctive for {len(json_files)} files...")
        
        for i, filename in enumerate(json_files, 1):
            filepath = os.path.join(self.verb_directory, filename)
            corrected = self.correct_file(filepath)
            
            if corrected:
                self.corrected_files += 1
                print(f"{i:3d}/{len(json_files)}: {filename:<20} - Accents corrected")
            else:
                print(f"{i:3d}/{len(json_files)}: {filename:<20} - No changes needed")
        
        print(f"\nAccent correction completed. {self.corrected_files} files updated.")

if __name__ == "__main__":
    corrector = AccentCorrector()
    corrector.process_all_files()