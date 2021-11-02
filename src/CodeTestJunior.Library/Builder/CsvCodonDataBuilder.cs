using System.IO;
using System.Linq;
using CodonTestJunior.DataModel;

namespace CodonTestJunior.Builder
{
    public class CsvCodonDataBuilder
    {
        private const string StopKey = "stop";
        private const string StartKey = "start";
        private const string Splitter = "~";
        private const string NewLine = "\r\n";
        private const char Comma = ',';

        public TranslationMap Build(string codonTableFileName)
        {
            var file = new StreamReader(codonTableFileName);
            var fileContents = file.ReadToEnd();
            return BuildCodonDictionaryFromFileContents(fileContents);
        }

        private TranslationMap BuildCodonDictionaryFromFileContents(string fileContents)
        {
            var codonData = new TranslationMap();

            var lines = fileContents.Replace(NewLine, Splitter).Split(Splitter.ToCharArray().First());

            foreach (var line in lines) InsertValueIntoMapOrStartOrStopList(line, codonData);

            return codonData;
        }

        private void InsertValueIntoMapOrStartOrStopList(string line, TranslationMap translationTranslationMap)
        {
            var lineValues = line.Split(Comma);

            if (lineValues[1].ToLower() == StopKey) translationTranslationMap.Stops.Add(lineValues[0]);

            else if (lineValues[1].ToLower() == StartKey) translationTranslationMap.Starts.Add(lineValues[0]);

            else translationTranslationMap.CodonMap.Add(lineValues[0], lineValues[1]);
        }
    }
}