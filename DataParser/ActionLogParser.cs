using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;

namespace DataParser
{
    public class ActionLogParser
    {
        //For Testing Purposes Only
        public int logType;
        public ActionLogParser()
        {
            logType = -1;
        
        }

        public void parseInnerElement(XmlTextReader reader)
        {
            if (reader.NodeType == XmlNodeType.EndElement)
            {
                logType = -1;
                return;
            }
            switch (reader.Name)
            {
                case "b":
                    reader.Read();
                 //   entity.SourceAssetID = reader.Value;
                    break;
                case "c":
                    reader.Read();
                //    entity.TargetAssestID = reader.Value;
                    break;
                case "d":
                    reader.Read();
                    Console.WriteLine(reader.Value);
                    logType = int.Parse(reader.Value);
                    break;
                case "e":
                    reader.Read();
                    parseEField(reader.Value);
               //     entity.ActionDetail = reader.Value;
                    break;
                case "f":
                    reader.Read();
               //     entity.TimeStamp = DateTime.Parse(reader.Value);
                    break;
                case "g":
                    reader.Read();
                //    entity.LogIndex = int.Parse(reader.Value);
                    break;
                default:
                    break;

            }
            Console.WriteLine(reader.Value);

            reader.Read();

        }

        public string parseEField(string eFieldValue)
        {
            string json = "";
            var serializer = new JavaScriptSerializer();
            Console.WriteLine(logType);
            switch (logType)
            {
                case 1:
                    DataStruct.Roadblock road = parseForRoadBlock(eFieldValue);
                    json = serializer.Serialize(road);
                    break;
                case 6:
                    DataStruct.DamageEntity dmg = parseForDamageEntity(eFieldValue);
                    json = serializer.Serialize(dmg);
                    break;
                case 9:
                    DataStruct.Rubble rubble = parseForRubble(eFieldValue);
                    json = serializer.Serialize(rubble);
                    break;
                case 10:
                    DataStruct.RubbleUpdate update = parseForRubbleUpdate(eFieldValue);
                    json = serializer.Serialize(update);
                    break;
                case 11:
                    DataStruct.ToxicSmoke tox = parseForToxicSmoke(eFieldValue);
                    json = serializer.Serialize(tox);
                    break;
                case 12:
                    DataStruct.ChemicalEvent chem = parseForChemicalEvent(eFieldValue);
                    json = serializer.Serialize(chem);
                    break;
                case 20:
                    DataStruct.EntityProperty ent = parseForEntityProperty(eFieldValue);
                    json = serializer.Serialize(ent);
                    break;

                default:
                    Console.WriteLine("No parser for that action log type");
                    return null;
            }

            return json;
        }

        public DataStruct.Roadblock parseForRoadBlock(string roadBlockString)
        {
            if (roadBlockString == null || roadBlockString == "")
                return new DataStruct.Roadblock() { Name = "-1" };

            String[] substrings = roadBlockString.Split('|');
            DataStruct.Roadblock roadBlock = new DataStruct.Roadblock();

            roadBlock.Name = substrings[0];
            roadBlock.ID = substrings[1];
            roadBlock.ImageID = substrings[2];
            roadBlock.startX = double.Parse(substrings[3]);
            roadBlock.startY = double.Parse(substrings[4]);
            roadBlock.endX = double.Parse(substrings[5]);
            roadBlock.endY = double.Parse(substrings[6]);

            return roadBlock;
        }

        public DataStruct.DamageEntity parseForDamageEntity(string eField)
        {
            if (eField == null || eField == "")
                return new DataStruct.DamageEntity() { damageID = "-1" };

            DataStruct.DamageEntity damaged = new DataStruct.DamageEntity();
            String[] substrings = eField.Split('|');

            damaged.damageID = substrings[0];
            damaged.injuryID = substrings[1];
            damaged.damage = int.Parse(substrings[2]);

            return damaged;
        }

        public DataStruct.Rubble parseForRubble(string rubbleString)
        {
            if (rubbleString == null || rubbleString == "")
                return new DataStruct.Rubble() { Name = "-1" };

            String[] substrings = rubbleString.Split('|');
            DataStruct.Rubble rubble = new DataStruct.Rubble();

            rubble.Name = substrings[0];
            rubble.EmergencyID = substrings[1];
            rubble.SoundID = substrings[2];
            rubble.ImageID = substrings[3];
            rubble.x = double.Parse(substrings[4]);
            rubble.y = double.Parse(substrings[5]);
            rubble.status = substrings[6];
            rubble.width = double.Parse(substrings[7]);
            rubble.height = double.Parse(substrings[8]);
            rubble.length = double.Parse(substrings[9]);
            rubble.BuildingID = substrings[10];

            return rubble;
        }

        public DataStruct.RubbleUpdate parseForRubbleUpdate(string rubbleUpdateString)
        {
            if (rubbleUpdateString == null || rubbleUpdateString == "")
                return new DataStruct.RubbleUpdate() { EmergencyID = "-1" };

            String[] substrings = rubbleUpdateString.Split('|');
            DataStruct.RubbleUpdate rubble = new DataStruct.RubbleUpdate();

            rubble.EmergencyID = substrings[0];
            rubble.peopleFound = int.Parse(substrings[1]);
            rubble.peopleRescued = int.Parse(substrings[2]);
            rubble.peopleTrapped = int.Parse(substrings[3]);
            rubble.volumeCleared = double.Parse(substrings[4]);
            rubble.volumeSearched = double.Parse(substrings[5]);

            return rubble;
        }

        public DataStruct.ToxicSmoke parseForToxicSmoke(string toxicSmokeString)
        {
            if (toxicSmokeString == null || toxicSmokeString == "")
            {
                return new DataStruct.ToxicSmoke() { Name = "-1" };
            }

            String[] substrings = toxicSmokeString.Split('|');
            DataStruct.ToxicSmoke toxicSmoke = new DataStruct.ToxicSmoke();

            toxicSmoke.Name = substrings[0];
            toxicSmoke.EmergencyID = substrings[1];
            toxicSmoke.concentration = double.Parse(substrings[2]);
            toxicSmoke.state = substrings[3];
            toxicSmoke.shape = substrings[4];

            return toxicSmoke;
        }

        public DataStruct.ChemicalEvent parseForChemicalEvent(string chemicalString)
        {
            if (chemicalString == null || chemicalString == "")
                return new DataStruct.ChemicalEvent() { Name = "-1" };

            String[] substrings = chemicalString.Split('|');
            DataStruct.ChemicalEvent chemicalEvent = new DataStruct.ChemicalEvent();

            chemicalEvent.Name = substrings[0];
            chemicalEvent.EmergencyID = substrings[1];
            chemicalEvent.ChemicalID = substrings[2];
            chemicalEvent.x = double.Parse(substrings[3]);
            chemicalEvent.y = double.Parse(substrings[4]);
            chemicalEvent.state = substrings[5];

            return chemicalEvent;
        }

        public DataStruct.EntityProperty parseForEntityProperty(string entityString)
        {
            if (entityString == null || entityString == "")
                return new DataStruct.EntityProperty() { attributeName = "-1" };

            String[] substrings = entityString.Split(':');
            DataStruct.EntityProperty entityProperty = new DataStruct.EntityProperty();

            entityProperty.attributeName = substrings[0];

            if (entityProperty.attributeName == "L")
            {
                int index = substrings[1].LastIndexOf("-");
                string first = substrings[1].Substring(0, index);
                string second = substrings[1].Substring(index + 1);

                entityProperty.value = first + '|' + second;
            }
            
            else 
                entityProperty.value = substrings[1];

            return entityProperty;
        }

        public DataStruct.AddLiveEmergency parseForAddLiveEmergency(string liveEmergencyString)
        {
            if (liveEmergencyString == null || liveEmergencyString == "")
                return new DataStruct.AddLiveEmergency() { ID = "-1" };

            String[] substrings = liveEmergencyString.Split('|');

            DataStruct.AddLiveEmergency liveEmergency = new DataStruct.AddLiveEmergency();

            liveEmergency.ID = substrings[0];
            liveEmergency.EmergencyID = substrings[1];

            return liveEmergency;
        }

        public DataStruct.AddLiveInfection parseForAddLiveInfection(string liveInfectionString)
        {
            if (liveInfectionString == null || liveInfectionString == "")
                return new DataStruct.AddLiveInfection() { ID = "-1" };

            String[] substrings = liveInfectionString.Split('|');

            DataStruct.AddLiveInfection liveInfection = new DataStruct.AddLiveInfection();

            liveInfection.ID = substrings[0];
            liveInfection.EmergencyID = substrings[1];

            return liveInfection;
        }

        public DataStruct.AddLiveSymptom parseForAddLiveSymptom(string liveSymptomString)
        {
            if (liveSymptomString == null || liveSymptomString == "")
                return new DataStruct.AddLiveSymptom() { SymptomTypeID = "-1" };

            String[] substrings = liveSymptomString.Split('|');

            DataStruct.AddLiveSymptom liveSymptom = new DataStruct.AddLiveSymptom();

            liveSymptom.SymptomTypeID = substrings[0];
            liveSymptom.InstanceID = substrings[1];
            liveSymptom.startTime = DateTime.Parse(substrings[2]);
            liveSymptom.endTime = DateTime.Parse(substrings[3]);

            return liveSymptom;
        }

        public DataStruct.GenericEmergency parseForGenericEmergency(string genericEmergencyString)
        {
            if (genericEmergencyString == null || genericEmergencyString == "")
                return new DataStruct.GenericEmergency() { eventNumber = -1 };

            String[] substrings = genericEmergencyString.Split('|');

            DataStruct.GenericEmergency genericEmergency = new DataStruct.GenericEmergency();

            genericEmergency.eventNumber = int.Parse(substrings[0]);
            genericEmergency.visibility = bool.Parse(substrings[1]);

            return genericEmergency;
        }

        public DataStruct.WeatherChange parseForWeatherChange(string weatherChangeString)
        {
            if (weatherChangeString == null || weatherChangeString == "")
                return new DataStruct.WeatherChange() { CloudCoverPercentage = -1 };

            String[] substrings = weatherChangeString.Split('|');

            DataStruct.WeatherChange weatherChange = new DataStruct.WeatherChange();

            weatherChange.CloudCoverPercentage = double.Parse(substrings[0]);
            weatherChange.MaxTemp = double.Parse(substrings[1]);
            weatherChange.MinTemp = double.Parse(substrings[2]);
            weatherChange.Precipitation = double.Parse(substrings[3]);
            weatherChange.MaxOpticalVisiblity = double.Parse(substrings[4]);
            weatherChange.WindSpeed = double.Parse(substrings[5]);
            weatherChange.WindDirection = double.Parse(substrings[6]);

            return weatherChange;
        }

        public DataStruct.GenericEmergencyEvent parseForGenericEmergencyEvent(string genericEmergencyString)
        {
            if (genericEmergencyString == null || genericEmergencyString == "")
                return new DataStruct.GenericEmergencyEvent() { GenericEmergencyID = "-1" };

            String[] substrings = genericEmergencyString.Split('|');
            DataStruct.GenericEmergencyEvent genericEmergencyEvent = new DataStruct.GenericEmergencyEvent();

            genericEmergencyEvent.GenericEmergencyID = substrings[0];
            genericEmergencyEvent.EventID = substrings[1];
            genericEmergencyEvent.Name = substrings[2];
            genericEmergencyEvent.Shape = substrings[3];
            genericEmergencyEvent.Colour = substrings[4];
            genericEmergencyEvent.Opacity = double.Parse(substrings[5]);
            genericEmergencyEvent.Icon = substrings[6];
            genericEmergencyEvent.Stretch = double.Parse(substrings[7]);
            genericEmergencyEvent.Visible = bool.Parse(substrings[8]);

            return genericEmergencyEvent;
        }

        public DataStruct.NewDetectedChemicalAmount parseForNewDetectedChemicalAmount(string newDetectedChemicalAmountString)
        {
            if (newDetectedChemicalAmountString == null || newDetectedChemicalAmountString == "")
                return new DataStruct.NewDetectedChemicalAmount() { value = -1 };

            DataStruct.NewDetectedChemicalAmount newDetectedChemicalAmount = new DataStruct.NewDetectedChemicalAmount();

            newDetectedChemicalAmount.value = double.Parse(newDetectedChemicalAmountString);

            return newDetectedChemicalAmount;
        }
    }
}
