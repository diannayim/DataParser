using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    public static class DataStruct
    {

        public struct Roadblock
        {
            public string Name;
            // This is going to change
            public string ID;
            // Don't need this, just the picture on the EDMSIM
            public string ImageID;
            // Start and end of roadblock
            public double startX, startY, endX, endY;

            public Roadblock(string name, string id, string imgid, double sx, double sy, double ex, double ey)
            {
                Name = name;
                ID = id;
                ImageID = imgid;
                startX = sx;
                startY = sy;
                endX = ex;
                endY = ey;
            }
        }

        public struct DamageEntity
        {
            // This is going to change
            public string damageID;
            public string injuryID;
            public int damage;

            public DamageEntity(string dmgID, string injID, int dmg)
            {
                damageID = dmgID;
                injuryID = injID;
                damage = dmg;
            }
        }

        public struct Rubble
        {
            // We have to talk about handling t-1, caused by whatever

            public string Name;
            public string EmergencyID;
            public string SoundID;
            public string ImageID;
            public double x;
            public double y;
            public string status;
            public double width;
            public double height;
            public double length;
            public string BuildingID;

            public Rubble(string n, string e, string s, string i, double xCoor, double yCoor, string stat, double w, double h, double l, string b)
            {
                Name = n;
                EmergencyID = e;
                SoundID = s;
                ImageID = i;
                x = xCoor;
                y = yCoor;
                status = stat;
                width = w;
                height = h;
                length = l;
                BuildingID = b;
            }
        }

        public struct RubbleUpdate
        {
            public string EmergencyID;
            public int peopleFound, peopleRescued, peopleTrapped;
            public double volumeCleared, volumeSearched;

            public RubbleUpdate(string e, int f, int r, int t, double c, double vs)
            {
                EmergencyID = e;
                peopleFound = f;
                peopleRescued = r;
                peopleTrapped = t;
                volumeCleared = c;
                volumeSearched = vs;
            }
        }

        public struct ToxicSmoke
        {
            public string Name, EmergencyID;
            public double concentration;
            public string state, shape;

            public ToxicSmoke(string n, string e, double c, string st, string sh)
            {
                Name = n;
                EmergencyID = e;
                concentration = c;
                state = st;
                shape = sh;
            }
        }

        public struct ChemicalEvent
        {
            public string Name, EmergencyID, ChemicalID;
            public double x, y;
            public string state;

            public ChemicalEvent(string n, string e, string c, double xCoor, double yCoor, string s)
            {
                Name = n;
                EmergencyID = e;
                ChemicalID = c;
                x = xCoor;
                y = yCoor;
                state = s;
            }
        }

        public struct EntityProperty
        {
            // Speed, actualSpeed, entityparent, entityvisibility, L, Heading, VehicleFuel, etc.
            public string attributeName;
            // Going to have to convert this before saving into the database
            public string value;

            public EntityProperty(string a, string v)
            {
                attributeName = a;
                value = v;
            }
        }

        public struct AddLiveEmergency
        {
            public string ID, EmergencyID;

            public AddLiveEmergency (string id, string emergID)
            {
                ID = id;
                EmergencyID = emergID;
            }
        }

        public struct AddLiveInfection
        {
            public string ID, EmergencyID;

            public AddLiveInfection(string id, string emergID)
            {
                ID = id;
                EmergencyID = emergID;
            }
        }

        public struct AddLiveSymptom
        {
            public string SymptomTypeID, InstanceID;
            public DateTime startTime, endTime;

            public AddLiveSymptom(string id, string instID, DateTime s, DateTime e)
            {
                SymptomTypeID = id;
                InstanceID = instID;
                startTime = s;
                endTime = e;
            }
        }

        public struct GenericEmergency
        {
            public int eventNumber;
            public bool visibility;

            public GenericEmergency(int eventNum, bool visi)
            {
                eventNumber = eventNum;
                visibility = visi;
            }
        }

        public struct WeatherChange
        {
            public double CloudCoverPercentage, MaxTemp, MinTemp, Precipitation, MaxOpticalVisiblity, WindSpeed, WindDirection;

            public WeatherChange(double cloud, double max, double min, double precip, double maxOptical, double wind, double dir)
            {
                CloudCoverPercentage = cloud;
                MaxTemp = max;
                MinTemp = min;
                Precipitation = precip;
                MaxOpticalVisiblity = maxOptical;
                WindSpeed = wind;
                WindDirection = dir;
            }
        }

        public struct GenericEmergencyEvent
        {
            public string GenericEmergencyID, EventID, Name, Shape, Colour;
            public double Opacity;
            public string Icon;
            public double Stretch;
            public bool Visible;

            public GenericEmergencyEvent(string g, string e, string n, string s, string c, double o, string i, double st, bool v)
            {
                GenericEmergencyID = g;
                EventID = e;
                Name = n;
                Shape = s;
                Colour = c;
                Opacity = o;
                Icon = i;
                Stretch = st;
                Visible = v;
            }
        }
    }
}
