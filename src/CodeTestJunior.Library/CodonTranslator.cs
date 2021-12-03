using CodonTestJunior.Builder;
using CodonTestJunior.DataModel;
using System;

namespace CodonTestJunior.Library
{
    /*  
     *  The genetic code is a set of rules by which DNA or mRNA is translated into proteins (amino acid sequences).
     *  
     *  1) Three nucleotides (or tri-nucleotide), called codons, specify which amino acid will be used.
     *  2) Since codons are defined by three nucleotides, every sequence can be read in three reading frames, depending on the starting point.
     *     The actual reading frame used for translation is determined by a start codon. 
     *     In our case, we will define the start codon to be the most commonly used ATG (in some organisms there may be other start codons).
     *  3) Translation begins with the start codon, which is translated as Methionine (abbreviated as 'M').
     *  4) Translation continues until a stop codon is encountered. There are three stop codons (TAG, TGA, TAA)
     *  
     * 
     *  Included in this project is a comma seperated value (CSV) text file with the codon translations.
     *  Each line of the file has the codon, followed by a space, then the amino acid (or start or stop)
     *  For example, the first line:
     *  CTA,L
     *  should be interpreted as: "the codon CTA is translated to the amino acid L"
     *  
     *  
     *  You should not assume that the input sequence begins with the start codon. Any nucleotides before the start codon should be ignored.
     *  You should not assume that the input sequence ends with the stop codon. Any nucleotides after the stop codon should be ignored.
     * 
     *  For example, if the input DNA sequence is GAACAAATGCATTAATACAAAAA, the output amino acid sequence is MH.
     *  GAACAA ATG CAT TAA TACAAAAA
     *         \ / \ /
     *          M   H
     *          
     *  ATG -> START -> M
     *  CAT -> H
     *  TAA -> STOP
     *  
     */


    public class CodonTranslator
    {
        private TranslationMap _translationMap;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="codonTableFileName">Filename of the DNA codon table.</param>
        public CodonTranslator(string codonTableFileName)
        {
            _translationMap = new CsvCodonDataBuilder().Build(codonTableFileName);
        }

        /// <summary>
        /// Translates a sequence of DNA into a sequence of amino acids.
        /// </summary>
        /// <param name="dna">DNA sequence to be translated.</param>
        /// <returns>Amino acid sequence</returns>
        public string Translate(string dna)
        {
            var proteinSequence = "";
            var start = "ATG";
            var stop1 = "TAG";
            var stop2 = "TGA";
            var stop3 = "TAA";
            char[] frame = new char[];


            
            // Search for the start codon (ATG).
            var start_loc = dna.IndexOf(start);

            // Search for one of the stop codons.
            var stop1_loc = dna.IndexOf(stop1);
            var stop2_loc =dna.IndexOf(stop2);
            var stop3_loc =dna.IndexOf(stop3);

            var stop_loc;
            // Search for the stop codon location.
            // **NOTE** If multiple stops exist, this could be buggy.
            if (stop1_loc > stop2_loc)
            {
                if (stop1_loc > stop3_loc)
                {
                    stop_loc = stop1_loc;
                }
                else
                {
                    stop_loc = stop3_loc;
                }
            }
            else if (stop2_loc > stop3_loc)
            {
                stop_loc = stop2_loc;
            }
            else
            {
                stop_loc = stop3_loc;
            }

            // Once start and stop locations are identified, break into sets of codons (maybe stored as an array for each codon?)
            // Loop through from start to stop and make a new array that excludes anything outside the start and stop.
            for (int i = start_loc; i <= stop_loc; i++)
            {
                
            }

            // Query the CSV file to find the name of the codon

            // Make a new array for the protein abbreviations.

            // Turn protein array into a string.

            // Return the corresponding protein string
            return proteinSequence;
        }
    }
}