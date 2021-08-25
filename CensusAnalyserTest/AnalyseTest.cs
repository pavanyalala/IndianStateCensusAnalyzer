using NUnit.Framework;
using System.Collections.Generic;
using IndianStateCensusAnalyser.POCO;
using static IndianStateCensusAnalyser.POCO.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static readonly string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static readonly string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static readonly string indianStateCensusFilePath = @"D:\dotnet\IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static readonly string indianStateCodeFilePath = @"D:\dotnet\IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static readonly string wrongHeaderIndianCensusFilePath = @"D:\dotnet\IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static readonly string delimiterIndianCensusFilePath = @"D:\dotnet\IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static readonly string wrongIndianStateCensusFileType = @"D:\dotnet\IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";
        static readonly string wrongIndianStateCodeFileType = @"D:\dotnet\IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        static readonly string delimiterIndianStateCodeFilePath = @"D:\dotnet\IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static readonly string wrongHeaderStateCodeFilePath = @"D:\dotnet\IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";
        static readonly string wrongIndianStateCensusFilePath = @"D:\dotnet\IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\IndiaData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }
        /// <summary>
        /// Test case 1.1
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReade_ThenShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        /// <summary>
        /// Test Case 1.2
        /// </summary>

        [Test]
        public void GivenIndianCensusDataFile_WhenIncorrect_ThenShouldReturnFileNotFoundException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        /// <summary>
        /// Test Case 1.3
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenFileTypeIncorrect_ThenShouldReturnInvalidFileTypeException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        /// <summary>
        /// Test Case 1.4
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenDelimiterIncorrect_ThenShouldReturnInvalidDelimiterException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        /// <summary>
        /// Test Case 1.5
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenHeaderIncorrect_ThenShouldReturnInvalidHeaderException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}