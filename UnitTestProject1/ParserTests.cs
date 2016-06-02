using System;
using DataParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ParserTests
    {
        ActionLogParser parser;

        [TestInitialize]
        public void init()
        {
            parser = new ActionLogParser();
        }

        #region parseForRoadBlock
        [TestMethod]
        public void Test_parseSetRoadBlock()
        {
            //Arrange
            string roadBlockString = "Road Block|526fbe63-dc77-4317-92c4-ed00a5300e36|1134|-113.997390252696|51.082128516755|-113.997390252696|51.081058191634";
            DataStruct.Roadblock check = new DataStruct.Roadblock("Road Block", "526fbe63-dc77-4317-92c4-ed00a5300e36", "1134", -113.997390252696, 51.082128516755, -113.997390252696, 51.081058191634);
            //Act
            DataStruct.Roadblock test = parser.parseForRoadBlock(roadBlockString);
            //Assert
            Assert.AreEqual(check.Name, test.Name, "Failed to Check Name");
            Assert.AreEqual(check.ID, test.ID, "Failed to Check ID");
            Assert.AreEqual(check.ImageID, test.ImageID, "Failed to Check ImageID");
            Assert.AreEqual(check.startX, test.startX, "Failed to Check startX");
            Assert.AreEqual(check.startY, test.startY, "Failed to Check startY");
            Assert.AreEqual(check.endX, test.endX, "Failed to Check endX");
            Assert.AreEqual(check.endY, test.endY, "Failed to Check endY");
        }

        [TestMethod]
        public void TestNull_parseSetRoadBlock()
        {
            //Arrange
            string roadBlockString = null;
            //Act
            DataStruct.Roadblock test = parser.parseForRoadBlock(roadBlockString);
            //Assert
            Assert.AreEqual("-1", test.Name, "Failed to return -1 for when you input a null string");
           }

        [TestMethod]
        public void TestEmpty_parseSetRoadBlock()
        {
            //Arrange
            string roadBlockString = "";
            //Act
            DataStruct.Roadblock test = parser.parseForRoadBlock(roadBlockString);
            //Assert
            Assert.AreEqual("-1", test.Name, "Failed to return -1 for when you input an empty string");
        }

        #endregion

        #region parseForDamageEntity 
        [TestMethod]
        public void Test_parseDamageEntity()
        {
            //Arrange
            string eField = "88166796-80b4-4425-8cfc-1eb4221e24a4|f00e2d12-6927-46b4-a3e3-47c9aea86b01|1";

            DataParser.DataStruct.DamageEntity check = new DataParser.DataStruct.DamageEntity("88166796-80b4-4425-8cfc-1eb4221e24a4", "f00e2d12-6927-46b4-a3e3-47c9aea86b01", 1);
            //Act
            DataStruct.DamageEntity test = parser.parseForDamageEntity(eField);
            //Assert
            Assert.AreEqual(check.damageID, test.damageID, "Failed to Check damageID");
            Assert.AreEqual(check.injuryID, test.injuryID, "Failed to Check injuryID");
            Assert.AreEqual(check.damage, test.damage, "Failed to Check damage");
        }

        [TestMethod]
        public void TestEFieldNull_parseDamageEntity()
        {
            //Arrange
            string eField = null;
            //Act
            DataStruct.DamageEntity test = parser.parseForDamageEntity(eField);
            //Assert
            Assert.AreEqual("-1", test.damageID, "Failed to return -1 for when you input a null e-field entity");
        }

        [TestMethod]
        public void TestEFieldEmpty_parseDamageEntity()
        {
            //Arrange
            string eField = "";
            //Act
            DataStruct.DamageEntity test = parser.parseForDamageEntity(eField);
            //Assert
            Assert.AreEqual("-1", test.damageID, "Failed to return -1 for when you input an empty e-field entity");
        }

        #endregion

        #region parseRubble
        [TestMethod]
        public void Test_parseRubble()
        {
            //Arrange
            string rubbleString = "Rubble of Commercial Business|baa2ff88-38d1-4b89-a457-a99c6c89f0e9|0|1101|-133.997240692865|51.0835884350652|Launched|4|1|5|7230e053-a285-4b5a-9ee5-bc721d9bb5c7";
            DataParser.DataStruct.Rubble check = new DataParser.DataStruct.Rubble("Rubble of Commercial Business", "baa2ff88-38d1-4b89-a457-a99c6c89f0e9", "0", "1101", -133.997240692865, 51.0835884350652, "Launched", 4, 1, 5, "7230e053-a285-4b5a-9ee5-bc721d9bb5c7");
            //Act
            DataStruct.Rubble test = parser.parseForRubble(rubbleString);
            //Assert
            Assert.AreEqual(check.Name, test.Name, "Failed to Check Name");
            Assert.AreEqual(check.EmergencyID, test.EmergencyID, "Failed to Check EmergencyID");
            Assert.AreEqual(check.SoundID, test.SoundID, "Failed to Check SoundID");
            Assert.AreEqual(check.ImageID, test.ImageID, "Failed to Check ImageID");
            Assert.AreEqual(check.x, test.x, "Failed to Check x");
            Assert.AreEqual(check.y, test.y, "Failed to Check y");
            Assert.AreEqual(check.status, test.status, "Failed to Check status");
            Assert.AreEqual(check.width, test.width, "Failed to Check width");
            Assert.AreEqual(check.height, test.height, "Failed to Check height");
            Assert.AreEqual(check.length, test.length, "Failed to Check length");
            Assert.AreEqual(check.BuildingID, test.BuildingID, "Failed to Check BuildingID");
        }

        [TestMethod]
        public void TestNull_parseRubble()
        {
            //Arrange
            string rubbleString = null;
            //Act
            DataStruct.Rubble test = parser.parseForRubble(rubbleString);
            //Assert
            Assert.AreEqual("-1", test.Name, "Failed to return -1 for when you input a null string");
        }

        [TestMethod]
        public void TestEmpty_parseRubble()
        {
            //Arrange
            string rubbleString = "";
            //Act
            DataStruct.Rubble test = parser.parseForRubble(rubbleString);
            //Assert
            Assert.AreEqual("-1", test.Name, "Failed to return -1 for when you input a null string");
        }
        #endregion

        #region parseRubbleUpdate
        [TestMethod]
        public void Test_parseRubbleUpdate()
        {
            //Arrange
            string rubbleUpdateString = "baa2ff88-38d1-4b89-a457-a99c6c89f0e9|0|0|15|0|0";
            DataParser.DataStruct.RubbleUpdate check = new DataParser.DataStruct.RubbleUpdate("baa2ff88-38d1-4b89-a457-a99c6c89f0e9", 0, 0, 15, 0, 0);
            //Act
            DataStruct.RubbleUpdate test = parser.parseForRubbleUpdate(rubbleUpdateString);
            //Assert
            Assert.AreEqual(check.EmergencyID, test.EmergencyID, "Failed to Check EmergencyID");
            Assert.AreEqual(check.peopleFound, test.peopleFound, "Failed to Check peopleFound");
            Assert.AreEqual(check.peopleRescued, test.peopleRescued, "Failed to Check peopleRescued");
            Assert.AreEqual(check.peopleTrapped, test.peopleTrapped, "Failed to Check peopleTrapped");
            Assert.AreEqual(check.volumeCleared, test.volumeCleared, "Failed to Check volumeCleared");
            Assert.AreEqual(check.volumeSearched, test.volumeSearched, "Failed to Check volumeSearched");
        }

        [TestMethod]
        public void TestNull_parseRubbleUpdate()
        {
            //Arrange
            string rubbleUpdateString = null;
            //Act
            DataStruct.RubbleUpdate test = parser.parseForRubbleUpdate(rubbleUpdateString);
            //Assert
            Assert.AreEqual("-1", test.EmergencyID, "Failed to return -1 for when you input a null string");
        }

        [TestMethod]
        public void TestEmpty_parseRubbleUpdate()
        {
            //Arrange
            string rubbleString = "";
            //Act
            DataStruct.RubbleUpdate test = parser.parseForRubbleUpdate(rubbleString);
            //Assert
            Assert.AreEqual("-1", test.EmergencyID, "Failed to return -1 for when you input a null string");
        }
        #endregion

        #region parseToxicSmoke
        [TestMethod]
        public void Test_parseToxicSmoke()
        {
            //Arrange
            string toxicSmokeString = "Chemical cloud.|944dcd2f-2f92-4705-a674-9c6f91c18cec|180|Launched|0:180;-113.95676032983,51.0722690518968;-113.956664255785,51.0723294189893;-113.956730768585,51.0725476685897;-113.956959868231,51.0726173225008;-113.957240700054,51.0725801737612;-113.957262870988,51.0723247753696;-113.957026381031,51.0722551210181;-113.95676032983,51.0722690518968;";
            DataParser.DataStruct.ToxicSmoke check = new DataParser.DataStruct.ToxicSmoke("Chemical cloud.", "944dcd2f-2f92-4705-a674-9c6f91c18cec", 180, "Launched", "0:180;-113.95676032983,51.0722690518968;-113.956664255785,51.0723294189893;-113.956730768585,51.0725476685897;-113.956959868231,51.0726173225008;-113.957240700054,51.0725801737612;-113.957262870988,51.0723247753696;-113.957026381031,51.0722551210181;-113.95676032983,51.0722690518968;");
            //Act
            DataStruct.ToxicSmoke test = parser.parseForToxicSmoke(toxicSmokeString);
            //Assert
            Assert.AreEqual(check.Name, test.Name, "Failed to Check Name");
            Assert.AreEqual(check.EmergencyID, test.EmergencyID, "Failed to Check EmergencyID");
            Assert.AreEqual(check.concentration, test.concentration, "Failed to Check concentration");
            Assert.AreEqual(check.state, test.state, "Failed to Check state");
            Assert.AreEqual(check.shape, test.shape, "Failed to Check shape");
        }

        [TestMethod]
        public void TestNull_parseToxicSmoke()
        {
            //Arrange
            string toxicSmokeString = null;
            //Act
            DataStruct.ToxicSmoke test = parser.parseForToxicSmoke(toxicSmokeString);
            //Assert
            Assert.AreEqual("-1", test.Name, "Failed to return -1 for when you input a null string");
        }

        [TestMethod]
        public void TestEmpty_parseToxicSmoke()
        {
            //Arrange
            string toxicSmokeString = "";
            //Act
            DataStruct.ToxicSmoke test = parser.parseForToxicSmoke(toxicSmokeString);
            //Assert
            Assert.AreEqual("-1", test.Name, "Failed to return -1 for when you input a null string");
        }
        #endregion

        #region parseChemicalEvent
        [TestMethod]
        public void Test_parseChemicalEvent()
        {
            //Arrange
            string chemicalString = "Chemical|944dcd2f-2f92-4705-a674-9c6f91c18cec|e8772622-8756-49e2-959f-fdcd37415072|-113.956949310543|51.0724176476622|Launched";
            DataStruct.ChemicalEvent check = new DataStruct.ChemicalEvent("Chemical", "944dcd2f-2f92-4705-a674-9c6f91c18cec", "e8772622-8756-49e2-959f-fdcd37415072", -113.956949310543, 51.0724176476622, "Launched");
            //Act
            DataStruct.ChemicalEvent test = parser.parseForChemicalEvent(chemicalString);
            //Assert
            Assert.AreEqual(check.Name, test.Name, "Failed to Check Name");
            Assert.AreEqual(check.EmergencyID, test.EmergencyID, "Failed to Check EmergencyID");
            Assert.AreEqual(check.ChemicalID, test.ChemicalID, "Failed to Check ChemicalID");
            Assert.AreEqual(check.x, test.x, "Failed to Check x");
            Assert.AreEqual(check.y, test.y, "Failed to Check y");
            Assert.AreEqual(check.state, test.state, "Failed to Check state");
        }

        [TestMethod]
        public void TestNull_parseChemicalEvent()
        {
            //Arrange
            string chemicalString = null;
            //Act
            DataStruct.ToxicSmoke test = parser.parseForToxicSmoke(chemicalString);
            //Assert
            Assert.AreEqual("-1", test.Name, "Failed to return -1 for when you input a null string");
        }

        [TestMethod]
        public void TestEmpty_parseChemicalEvent()
        {
            //Arrange
            string chemicalString = "";
            //Act
            DataStruct.ToxicSmoke test = parser.parseForToxicSmoke(chemicalString);
            //Assert
            Assert.AreEqual("-1", test.Name, "Failed to return -1 for when you input a null string");
        }
        #endregion

        #region parseEntityProperty
        [TestMethod]
        public void Test_parseEntityProperty()
        {
            //Arrange
            string entityString = "Heading:213.048182923301";
            DataStruct.EntityProperty check = new DataStruct.EntityProperty("Heading", "213.048182923301");
            //Act
            DataStruct.EntityProperty test = parser.parseForEntityProperty(entityString);
            //Assert
            Assert.AreEqual(check.attributeName, test.attributeName, "Failed to Check attributeName");
            Assert.AreEqual(check.value, test.value, "Failed to Check value");
        }

        [TestMethod]
        public void TestL_parseEntityProperty()
        {
            //Arrange
            string entityString = "L:-114.045651749628-51.1106520506276";
            DataStruct.EntityProperty check = new DataStruct.EntityProperty("L", "-114.045651749628|51.1106520506276");
            //Act
            DataStruct.EntityProperty test = parser.parseForEntityProperty(entityString);
            //Assert
            Assert.AreEqual(check.attributeName, test.attributeName, "Failed to Check attributeName");
            Assert.AreEqual(check.value, test.value, "Failed to Check value");
        }

        [TestMethod]
        public void TestNull_parseEntityProperty()
        {
            //Arrange
            string entityString = null;
            //Act
            DataStruct.EntityProperty test = parser.parseForEntityProperty(entityString);
            //Assert
            Assert.AreEqual("-1", test.attributeName, "Failed to return -1 for when you input a null string");
        }

        [TestMethod]
        public void TestEmpty_parseEntityProperty()
        {
            //Arrange
            string entityString = "";
            //Act
            DataStruct.EntityProperty test = parser.parseForEntityProperty(entityString);
            //Assert
            Assert.AreEqual("-1", test.attributeName, "Failed to return -1 for when you input a null string");
        }
        #endregion

        #region parseAddLiveEmergency
        [TestMethod]
        public void Test_parseAddLiveEmergency()
        {
            //Arrange
            string liveEmergencyString = "653aab10-91b8-4d5b-b034-90ea936d6070|944dcd2f-2f92-4705-a674-9c6f91c18cec";
            DataStruct.AddLiveEmergency check = new DataStruct.AddLiveEmergency("653aab10-91b8-4d5b-b034-90ea936d6070", "944dcd2f-2f92-4705-a674-9c6f91c18cec");
            //Act
            DataStruct.AddLiveEmergency test = parser.parseForAddLiveEmergency(liveEmergencyString);
            //Assert
            Assert.AreEqual(check.ID, test.ID, "Failed to Check ID");
            Assert.AreEqual(check.EmergencyID, test.EmergencyID, "Failed to Check value");
        }

        [TestMethod]
        public void TestNull_parseAddLiveEmergency()
        {
            //Arrange
            string liveEmergencyString = null;
            //Act
            DataStruct.AddLiveEmergency test = parser.parseForAddLiveEmergency(liveEmergencyString);
            //Assert
            Assert.AreEqual("-1", test.ID, "Failed to return -1 for when you input a null string");
        }

        [TestMethod]
        public void TestEmpty_parseAddLiveEmergency()
        {
            //Arrange
            string liveEmergencyString = "";
            //Act
            DataStruct.AddLiveEmergency test = parser.parseForAddLiveEmergency(liveEmergencyString);
            //Assert
            Assert.AreEqual("-1", test.ID, "Failed to return -1 for when you input a null string");
        }
        #endregion

        #region parseAddLiveInfection
        [TestMethod]
        public void Test_parseAddLiveInfection()
        {
            //Arrange
            string liveInfectionString = "c909c702-5f63-421a-a510-4fa49f4aab41|c909c702-5f63-421a-a510-4fa49f4aab41";
            DataStruct.AddLiveInfection check = new DataStruct.AddLiveInfection("c909c702-5f63-421a-a510-4fa49f4aab41", "c909c702-5f63-421a-a510-4fa49f4aab41");
            //Act
            DataStruct.AddLiveInfection test = parser.parseForAddLiveInfection(liveInfectionString);
            //Assert
            Assert.AreEqual(check.ID, test.ID, "Failed to Check ID");
            Assert.AreEqual(check.EmergencyID, test.EmergencyID, "Failed to Check value");
        }

        [TestMethod]
        public void TestNull_parseAddLiveInfection()
        {
            //Arrange
            string liveInfectionString = null;
            //Act
            DataStruct.AddLiveInfection test = parser.parseForAddLiveInfection(liveInfectionString);
            //Assert
            Assert.AreEqual("-1", test.ID, "Failed to return -1 for when you input a null string");
        }

        [TestMethod]
        public void TestEmpty_parseAddLiveInfection()
        {
            //Arrange
            string liveInfectionString = "";
            //Act
            DataStruct.AddLiveInfection test = parser.parseForAddLiveInfection(liveInfectionString);
            //Assert
            Assert.AreEqual("-1", test.ID, "Failed to return -1 for when you input a null string");
        }
        #endregion

        #region parseAddLiveSymptom
        [TestMethod]
        public void Test_parseAddLiveSymptom()
        {
            //Arrange
            string liveSymptomString = "88d90e41-1bee-4659-bf28-23e292aaf1a3|00ec7cf6-a8a7-4f0f-b0c4-a28ba4b699eb|08/11/2015 16:19:23|08/12/2015 16:19:23";
            DateTime start = DateTime.Parse("08/11/2015 16:19:23");
            DateTime end = DateTime.Parse("08/12/2015 16:19:23");
            DataStruct.AddLiveSymptom check = new DataStruct.AddLiveSymptom("88d90e41-1bee-4659-bf28-23e292aaf1a3", "00ec7cf6-a8a7-4f0f-b0c4-a28ba4b699eb", start, end);
            //Act
            DataStruct.AddLiveSymptom test = parser.parseForAddLiveSymptom(liveSymptomString);
            //Assert
            Assert.AreEqual(check.SymptomTypeID, test.SymptomTypeID, "Failed to Check SymptomTypeID");
            Assert.AreEqual(check.InstanceID, test.InstanceID, "Failed to Check InstanceID");
            Assert.AreEqual(check.startTime, test.startTime, "Failed to check startTime");
            Assert.AreEqual(check.endTime, test.endTime, "Failed to check endTime");
        }

        [TestMethod]
        public void TestNull_parseAddLiveSymptom()
        {
            //Arrange
            string liveSymptomString = null;
            //Act
            DataStruct.AddLiveSymptom test = parser.parseForAddLiveSymptom(liveSymptomString);
            //Assert
            Assert.AreEqual("-1", test.SymptomTypeID, "Failed to return -1 for when you input a null string");
        }

        [TestMethod]
        public void TestEmpty_parseAddLiveSymptom()
        {
            //Arrange
            string liveSymptomString = "";
            //Act
            DataStruct.AddLiveSymptom test = parser.parseForAddLiveSymptom(liveSymptomString);
            //Assert
            Assert.AreEqual("-1", test.SymptomTypeID, "Failed to return -1 for when you input a null string");
        }
        #endregion

        #region parseGenericEmergency
        [TestMethod]
        public void Test_parseGenericEmergency()
        {
            //Arrange
            string genericEmergencyString = "13|False";
            DataStruct.GenericEmergency check = new DataStruct.GenericEmergency(13, false);
            //Act
            DataStruct.GenericEmergency test = parser.parseForGenericEmergency(genericEmergencyString);
            //Assert
            Assert.AreEqual(check.eventNumber, test.eventNumber, "Failed to Check eventNumber");
            Assert.AreEqual(check.visibility, test.visibility, "Failed to Check visibility");
        }

        [TestMethod]
        public void TestNull_parseGenericEmergency()
        {
            //Arrange
            string genericEmergencyString = null;
            //Act
            DataStruct.GenericEmergency test = parser.parseForGenericEmergency(genericEmergencyString);
            //Assert
            Assert.AreEqual(-1, test.eventNumber, "Failed to return -1 for when you input a null string");
        }

        [TestMethod]
        public void TestEmpty_parseGenericEmergency()
        {
            //Arrange
            string genericEmergencyString = "";
            //Act
            DataStruct.GenericEmergency test = parser.parseForGenericEmergency(genericEmergencyString);
            //Assert
            Assert.AreEqual(-1, test.eventNumber, "Failed to return -1 for when you input a null string");
        }
        #endregion

        #region parseWeatherChange
        [TestMethod]
        public void Test_parseWeatherChange()
        {
            //Arrange
            string weatherChangeString = "100|18|8|3|22860|90|7";
            DataParser.DataStruct.WeatherChange check = new DataParser.DataStruct.WeatherChange(100, 18, 8, 3, 22860, 90, 7);
            //Act
            DataStruct.WeatherChange test = parser.parseForWeatherChange(weatherChangeString);
            //Assert
            Assert.AreEqual(check.CloudCoverPercentage, test.CloudCoverPercentage, "Failed to Check CloudCoverPercentage");
            Assert.AreEqual(check.MaxTemp, test.MaxTemp, "Failed to Check MaxTemp");
            Assert.AreEqual(check.MinTemp, test.MinTemp, "Failed to Check MinTemp");
            Assert.AreEqual(check.Precipitation, test.Precipitation, "Failed to Check Precipitation");
            Assert.AreEqual(check.MaxOpticalVisiblity, test.MaxOpticalVisiblity, "Failed to Check MaxOpticalVisiblity"); 
            Assert.AreEqual(check.WindSpeed, test.WindSpeed, "Failed to Check WindSpeed");
            Assert.AreEqual(check.WindDirection, test.WindDirection, "Failed to Check WindDirection");

        }

        [TestMethod]
        public void TestNull_parseWeatherChange()
        {
            //Arrange
            string weatherChangeString = null;
            //Act
            DataStruct.WeatherChange test = parser.parseForWeatherChange(weatherChangeString);
            //Assert
            Assert.AreEqual(-1, test.CloudCoverPercentage, "Failed to return -1 for when you input a null string");
        }

        [TestMethod]
        public void TestEmpty_parseWeatherChange()
        {
            //Arrange
            string weatherChangeString = "";
            //Act
            DataStruct.WeatherChange test = parser.parseForWeatherChange(weatherChangeString);
            //Assert
            Assert.AreEqual(-1, test.CloudCoverPercentage, "Failed to return -1 for when you input a null string");
        }
        #endregion

        #region parseGenericEmergencyEvent
        [TestMethod]
        public void Test_parseGenericEmergencyEvent()
        {
            //Arrange
            string genericEmergencyString = "1|1|t-7|POLYGON ((-113.93537700715 51.0736129623831, -113.929223980213 51.0738741831675, -113.925731721681 51.0731427612551, -113.920742780921 51.072724800686, -113.915005499047 51.0728292911822, -113.910515452364 51.0722545905336, -113.9100997073 51.070112461603, -113.9100997073 51.0673954725294, -113.914257157933 51.066402686736, -113.921906867098 51.0657756531582, -113.932300493681 51.0664549391507, -113.935875901226 51.0673954725294, -113.93537700715 51.0736129623831))|-4128769|0.2|-1|1|False";
            DataParser.DataStruct.GenericEmergencyEvent check = new DataParser.DataStruct.GenericEmergencyEvent("1", "1", "t-7", "POLYGON ((-113.93537700715 51.0736129623831, -113.929223980213 51.0738741831675, -113.925731721681 51.0731427612551, -113.920742780921 51.072724800686, -113.915005499047 51.0728292911822, -113.910515452364 51.0722545905336, -113.9100997073 51.070112461603, -113.9100997073 51.0673954725294, -113.914257157933 51.066402686736, -113.921906867098 51.0657756531582, -113.932300493681 51.0664549391507, -113.935875901226 51.0673954725294, -113.93537700715 51.0736129623831))", "-4128769", 0.2, "-1", 1, false);
            //Act
            DataStruct.GenericEmergencyEvent test = parser.parseForGenericEmergencyEvent(genericEmergencyString);
            //Assert
            Assert.AreEqual(check.GenericEmergencyID, test.GenericEmergencyID, "Failed to Check GenericEmergencyID");
            Assert.AreEqual(check.EventID, test.EventID, "Failed to Check EventID");
            Assert.AreEqual(check.Name, test.Name, "Failed to Check Name");
            Assert.AreEqual(check.Shape, test.Shape, "Failed to Check Shape");
            Assert.AreEqual(check.Colour, test.Colour, "Failed to Check Colour");
            Assert.AreEqual(check.Opacity, test.Opacity, "Failed to Check Opacity");
            Assert.AreEqual(check.Icon, test.Icon, "Failed to Check Icon");
            Assert.AreEqual(check.Stretch, test.Stretch, "Failed to Check Stretch");
            Assert.AreEqual(check.Visible, test.Visible, "Failed to Check Visible");
        }

        [TestMethod]
        public void TestNull_parseGenericEmergencyEvent()
        {
            //Arrange
            string genericEmergencyString = null;
            //Act
            DataStruct.GenericEmergencyEvent test = parser.parseForGenericEmergencyEvent(genericEmergencyString);
            //Assert
            Assert.AreEqual("-1", test.GenericEmergencyID, "Failed to return -1 for when you input a null string");
        }

        [TestMethod]
        public void TestEmpty_parseGenericEmergencyEvent()
        {
            //Arrange
            string genericEmergencyString = "";
            //Act
            DataStruct.GenericEmergencyEvent test = parser.parseForGenericEmergencyEvent(genericEmergencyString);
            //Assert
            Assert.AreEqual("-1", test.GenericEmergencyID, "Failed to return -1 for when you input a null string");
        }
        #endregion

        [TestMethod]
        public void Test_ActionLogParser()
        {
            parser.logType = 20;
            string entityString = "Heading:213.048182923301";
            string check = "{\"attributeName\":\"Heading\",\"value\":\"213.048182923301\"}";

            string test = parser.parseEField(entityString);
            Assert.AreEqual(check, test);
        }
    }
}
