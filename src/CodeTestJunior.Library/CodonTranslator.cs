using CodonTestJunior.Builder;
using CodonTestJunior.DataModel;
using System.Collections.Generic;

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
            string translation = "";
            int index;
            List<string> codons;

            if (dna.Contains("ATG"))
            {
                translation += "M";
                index = dna.IndexOf("ATG") + 3;
                codons = SplitCodons(dna.Substring(index));

                foreach (string codon in codons)
                {
                    if (_translationMap.Stops.Contains(codon))
                    {
                        break;
                    }

                    translation += _translationMap.CodonMap[codon].ToString();
                }
            }

            return translation;
        }

        /// <summary>
        /// Split the dna substring into list of codons.
        /// </summary>
        /// <param name="dnaSubstring"></param>
        /// <returns>List of codons</returns>
        private List<string> SplitCodons(string dnaSubstring)
        {
            List<string> codons = new List<string>();
            int index = 0;
            while (index + 3 < dnaSubstring.Length)
            {
                codons.Add(dnaSubstring.Substring(index, 3));
                index += 3;
            }

            return codons;
        }
    }
}