
## Introduction
The genetic code is a set of rules by which DNA or mRNA is translated into proteins (amino acid sequences).

1. Three nucleotides (or tri-nucleotide), called codons, specify which amino acid will be used.
2. Since codons are defined by three nucleotides, every sequence can be read in three reading frames, depending on the starting point. The actual reading frame used for translation is determined by a start codon. 
In our case, we will define the start codon to be the most commonly used ATG (in some organisms there may be other start codons).
3. Translation begins with the start codon, which is translated as Methionine (abbreviated as 'M').
4. Translation continues until a stop codon is encountered. There are three stop codons (TAG, TGA, TAA)

## Instructions

- The objective of this coding challenge is to complete the implementation for the CodonTranslator class in the codonTranslator.cs file to translate the provided codon sequences into their corresponding proteins based on the mappings provided in the data file.  

- Unit test have been provided in the CodonTranslatorTester.cs file.  Running the tests should give you an indication of the completeness of your solution. 

- You will have 1.5 hours from the time you are given the instructions to complete the challenge.  You will need to create a pull request before the time has elapsed. 

- You can use any resources at your disposal to complete the challenge, books, websites, MSDN.  However, you need to complete your own work.  Do not consult with anyone else. 

## Code

The code for this challenge can be found at https://github.com/bwkennedy/CodeTestJunior. You will need to fork the project, complete the challenge, and then create a pull request. See https://gist.github.com/Chaser324/ce0505fbed06b947d962 for instructions on creating a pull request with Github.

### Included in this project

1. CodonTranslator.cs - This is the code file for the CodonTranslator class you will need to complete
2. CodonTranslatorTester.cs - This file includes completed unit tests for the CodonTranslator class
3. CodonTable.csv - These are the data files that designate the start and stop codones, as well as the codon/protein mappings:

### Hints

1. You should not assume that the input sequence begins with the start codon. Any nucleotides before the start codon should be ignored.
2. You should not assume that the input sequence ends with the stop codon. Any nucleotides after the stop codon should be ignored.

### Example

If the input DNA sequence is GAACAAATGCATTAATACAAAAA, the output amino acid sequence is MH.

    GAACAA ATG CAT TAA TACAAAAA

               \ / \ /
                M   H
        
ATG -> START -> M

CAT -> H

TAA -> STOP