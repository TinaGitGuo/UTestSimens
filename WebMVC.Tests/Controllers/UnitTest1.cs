using System.Collections;
using System.IO;
using global::System;
using global::System.Collections.Generic;
using global::System.Diagnostics;
using global::Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualBasic.Devices;
using WebMVC.Tests.Controllers;
using Co = System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using   System.Runtime.Serialization.Formatters.Soap;
namespace WebMVC.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Create a list of accounts.
            var bankAccounts = new List<Account>
            {
                new Account {
                    ID = 345678,
                    Balance = 541.27
                },
                new Account {
                    ID = 1230221,
                    Balance = -127.44
                }
            };
           


            Walkthrough.DisplayInExcel(bankAccounts, (account, cell) =>
                // This multiline lambda expression sets custom processing rules
                // for the bankAccounts.
            {
                cell.Value = account.ID;
                cell.Offset[0, 1].Value = account.Balance;
                if (account.Balance < 0)
                {
                    cell.Interior.Color = 255;
                    cell.Offset[0, 1].Interior.Color = 255;
                }
            });

            // Display the list in an Excel spreadsheet.
            //Walkthrough. DisplayInExcel(bankAccounts);
            // Create a Word document that contains an icon that links to
            // the spreadsheet.
            Walkthrough.CreateIconInWordDoc();
        }
        [TestMethod]
        public void TestMethod2()
        {

            CustomException ex =
                new CustomException("Custom exception in TestThrow()");

            try
            {
                throw ex;
            }
            catch (CustomException exx)
            {
                Debug.WriteLine(exx.ToString());


            }
       


        }
        [TestMethod]
        public void TestMethod3()
        {
            // Play a sound with the Audio class:
            //Audio myAudio = new Audio();
            //Debug.WriteLine("Playing sound...");
            //myAudio.Play(@"c:\WINDOWS\Media\chimes.wav");
            // Display time information with the Clock class:
            Clock myClock = new Clock();
            Debug.Write("Current day of the week: ");
            Debug.WriteLine(myClock.LocalTime.DayOfWeek);
            Debug.Write("Current date and time: ");
            Debug.WriteLine(myClock.LocalTime);
            // Display machine information with the Computer class:
            Computer myComputer = new Computer();
            Debug.WriteLine("Computer name: " + myComputer.Name);
            if (myComputer.Network.IsAvailable)
            {
                Debug.WriteLine("Computer is connected to network.");
            }
            else
            {
                Debug.WriteLine("Computer is not connected to network.");
            }
        }

        [TestMethod]
        public void TestMethod4() { 

                //Creates a new TestSimpleObject object.
        TestSimpleObject obj = new TestSimpleObject();

                Console.WriteLine("Before serialization the object contains: ");
                obj.Print();

                //Opens a file and serializes the object into it in binary format.
                Stream stream = File.Open("data.xml", FileMode.Create);
                SoapFormatter formatter = new SoapFormatter();

                //BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, obj);
                stream.Close();

                //Empties obj.
                obj = null;

                //Opens file "data.xml" and deserializes the object from it.
                stream = File.Open("data.xml", FileMode.Open);
                formatter = new SoapFormatter();

                //formatter = new BinaryFormatter();

                obj = (TestSimpleObject)formatter.Deserialize(stream);
                stream.Close();

                Console.WriteLine("");
                Console.WriteLine("After deserialization the object contains: ");
                obj.Print();
            
        }


        // A test object that needs to be serialized.
        [Serializable()]
        public class TestSimpleObject
        {

            public int member1;
            public string member2;
            public string member3;
            public double member4;

            // A field that is not serialized.
            [NonSerialized()] public string member5;
            public TestSimpleObject()
            {

                member1 = 11;
                member2 = "hello";
                member3 = "hello";
                member4 = 3.14159265;
                member5 = "hello world!";
            }


            public void Print()
            {

                Console.WriteLine("member1 = '{0}'", member1);
                Console.WriteLine("member2 = '{0}'", member2);
                Console.WriteLine("member3 = '{0}'", member3);
                Console.WriteLine("member4 = '{0}'", member4);
                Console.WriteLine("member5 = '{0}'", member5);
            }
        }
        [STAThread]
        [TestMethod]
        public void TestMethod5()
        {
            Serialize();
            Deserialize();
        }
        public class Person
        {
            public Person(string firstName, string lastName)
            {
                fname = firstName;
                lname = lastName;
            }
            private string fname;
            private string lname;
            public override string ToString() => $"{fname} {lname}".Trim();
            public void DisplayName() => Console.WriteLine(ToString());
        }
        public class Location
        {
            private string locationName;
            public Location(string name) => Name = name;
            public string Name
            {
                get;
                set;
                //get => locationName;
                //set => locationName = value;
            }
        }
        static void Serialize()
        {
            // Create a hashtable of values that will eventually be serialized.
            Hashtable addresses = new Hashtable();
            addresses.Add("Jeff", "123 Main Street, Redmond, WA 98052");
            addresses.Add("Fred", "987 Pine Road, Phila., PA 19116");
            addresses.Add("Mary", "PO Box 112233, Palo Alto, CA 94301");

            // To serialize the hashtable and its key/value pairs,  
            // you must first open a stream for writing. 
            // In this case, use a file stream.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, addresses);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        partial struct Digit
        {
            byte value;
            public Digit(byte value) //constructor
            {
                if (value > 9)
                {
                    throw new System.ArgumentException();
                }
                this.value = value;
            }
            public static explicit operator Digit(byte b) // explicit byte to digit conversion operator
            {
                Digit d = new Digit(b); // explicit conversion
                System.Console.WriteLine("Conversion occurred.");
                return d;
            }
        }
        [TestMethod]
        public void TestMethod6()
        { 
                try
                {
                    byte b = 3;
                    Digit d = (Digit)b; // explicit conversion
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine("{0} Exception caught.", e);
                }
            
        }
        partial struct Digit
        {

            public static implicit operator byte(Digit d) // implicit digit to byte conversion operator
            {
                System.Console.WriteLine("conversion occurred");
                return d.value; // implicit conversion
            }

        }
        [TestMethod]
        public void TestMethod7()
        { 
                Digit d = new Digit(3);
                byte b = d; // implicit conversion -- no cast needed
            
        }
        // Output: Conversion occurred.

        static void Deserialize()
        {
            // Declare the hashtable reference.
            Hashtable addresses = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                addresses = (Hashtable)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            // To prove that the table deserialized correctly, 
            // display the key/value pairs.
            foreach (DictionaryEntry de in addresses)
            {
                Console.WriteLine("{0} lives at {1}.", de.Key, de.Value);
            }
        }
        [TestMethod]
        public void TestMethod8()
        {
            var s = default(string);
            var d = default(dynamic);
            var i = default(int);
            var n = default(int?); 

        }

        public struct Point
        {
            public double X { get; }
            public double Y { get; }
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
        public class LabeledPoint
        {
            public double X { get; private set; }
            public double Y { get; private set; }
            public string Label { get; set; }
            // Providing the value for a default argument:
            public LabeledPoint(double x, double y, string label = default)
            {
                X = x;
                Y = y;
                this.Label = label;
            }
            public static LabeledPoint MovePoint(LabeledPoint source,
                double xDistance, double yDistance)
            {
                // return a default value:
                if (source == null)
                    return default;
                return new LabeledPoint(source.X + xDistance, source.Y + yDistance,
                    source.Label);
            }
            public static LabeledPoint FindClosestLocation(IEnumerable<LabeledPoint> sequence,
                Point location)
            {
                // initialize variable:
                LabeledPoint rVal = default;
                double distance = double.MaxValue;
                foreach (var pt in sequence)
                {
                    var thisDistance = Math.Sqrt((pt.X - location.X) * (pt.X - location.X) +
                                                 (pt.Y - location.Y) * (pt.Y - location.Y));
                    if (thisDistance < distance)
                    {
                        distance = thisDistance;
                        rVal = pt;
                    }
                }
                return rVal;
            }
            public static LabeledPoint ClosestToOrigin(IEnumerable<LabeledPoint> sequence)
                // Pass default value of an argument.
                => FindClosestLocation(sequence, default);
        }

    }



}
namespace N1 // N1
{
    class C1 // N1.C1
    {
        class C2 // N1.C1.C2
        {

        }
    }
    namespace N2 // N1.N2
    {
        class C2 // N1.N2.C2
        {
        }
    }
    
}
namespace N1.N2
{
    class C3 // N1.N2.C3
    {
    }
}
