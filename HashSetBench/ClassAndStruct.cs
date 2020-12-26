using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetBench
{
    // this should be 8 bytes in size
    public struct SmallStruct : IEquatable<SmallStruct>
    {
        public int MyInt;
        public int MyInt2;

        public SmallStruct(int i, int i2)
        {
            MyInt = i;
            MyInt2 = i2;
        }

        public static SmallStruct CreateRand(Random rand)
        {
            int i = rand.Next(); // make this non-negative
            int i2 = rand.Next(); // make this non-negative

            return new SmallStruct(i, i2);
        }

        public override int GetHashCode()
        {
            int hash = 13;

            unchecked // the code below may overflow the hash int and that will cause an exception if compiler is checking for arithmetic overflow - unchecked prevents this
            {
                hash = (hash * 7) + MyInt;
                hash = (hash * 7) + MyInt2;
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SmallStruct))
            {
                return false;
            }

            return Equals((SmallStruct)obj);
        }

        public bool Equals(SmallStruct other)
        {
            return (MyInt == other.MyInt && MyInt2 == other.MyInt2);
        }

        public static bool operator ==(SmallStruct c1, SmallStruct c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(SmallStruct c1, SmallStruct c2)
        {
            return !c1.Equals(c2);
        }
    }

    public sealed class SmallClass : IEquatable<SmallClass>
    {
        public int MyInt;
        public int MyInt2;

        public SmallClass(int i, int i2)
        {
            MyInt = i;
            MyInt2 = i2;
        }

        public static SmallClass CreateRand(Random rand)
        {
            int i = rand.Next(); // make this non-negative
            int i2 = rand.Next(); // make this non-negative

            return new SmallClass(i, i2);
        }

        public override int GetHashCode()
        {
            int hash = 13;

            unchecked // the code below may overflow the hash int and that will cause an exception if compiler is checking for arithmetic overflow - unchecked prevents this
            {
                hash = (hash * 7) + MyInt;
                hash = (hash * 7) + MyInt2;
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return Equals(obj as SmallClass);
        }

        public bool Equals(SmallClass other)
        {
            if (other == null)
            {
                return false;
            }

            return (MyInt == other.MyInt && MyInt2 == other.MyInt2);
        }
    }

    public struct SmallStructIntVal : IEquatable<SmallStructIntVal>
    {
        public int MyInt;
        public int refCountOrSum;

        public SmallStructIntVal(int i, int refCountOrSum)
        {
            MyInt = i;
            this.refCountOrSum = refCountOrSum;
        }

        public override int GetHashCode()
        {
            return MyInt;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SmallStructIntVal))
            {
                return false;
            }

            return Equals((SmallStruct)obj);
        }

        public bool Equals(SmallStructIntVal other)
        {
            return (MyInt == other.MyInt);
        }

        public static bool operator ==(SmallStructIntVal c1, SmallStructIntVal c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(SmallStructIntVal c1, SmallStructIntVal c2)
        {
            return !c1.Equals(c2);
        }
    }

    public sealed class SmallClassIntVal : IEquatable<SmallClassIntVal>
    {
        public int MyInt;
        public int refCountOrSum;

        public SmallClassIntVal(int i, int refCountOrSum)
        {
            MyInt = i;
            this.refCountOrSum = refCountOrSum;
        }

        public override int GetHashCode()
        {
            return MyInt;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SmallClassIntVal);
        }

        public bool Equals(SmallClassIntVal other)
        {
            if (other == null)
            {
                return false;
            }

            return (MyInt == other.MyInt);
        }
    }

    // this should be 8 bytes in size
    public struct SmallStructBasic
    {
        public int MyInt;
        public int MyInt2;

        public SmallStructBasic(int i, int i2)
        {
            MyInt = i;
            MyInt2 = i2;
        }
    }

    public class SmallClassBasic
    {
        public int MyInt;
        public int MyInt2;

        public SmallClassBasic(int i, int i2)
        {
            MyInt = i;
            MyInt2 = i2;
        }
    }

    // this should be about 20 bytes in size (assuming DateTime is 8 bytes)
    public struct MediumStruct : IEquatable<MediumStruct>
    {
        public DateTime MyDate;
        public double MyDouble;
        public int MyInt;

        public MediumStruct(DateTime dt, double d, int i)
        {
            MyDate = dt;
            MyDouble = d;
            MyInt = i;
        }

        public static MediumStruct CreateRand(Random rand)
        {
            double d = rand.NextDouble();
            int i = rand.Next(); // make this non-negative
            int year = rand.Next(1990, 2019);
            int month = rand.Next(1, 12);
            int day = rand.Next(1, 28);

            return new MediumStruct(new DateTime(year, month, day), d, i);
        }

        public override int GetHashCode()
        {
            int hash = 13;

            unchecked // the code below may overflow the hash int and that will cause an exception if compiler is checking for arithmetic overflow - unchecked prevents this
            {
                hash = (hash * 7) + MyInt;
                hash = (hash * 7) + MyDouble.GetHashCode();
                hash = (hash * 7) + MyDate.GetHashCode();
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MediumStruct))
            {
                return false;
            }

            return Equals((MediumStruct)obj);
        }

        public bool Equals(MediumStruct other)
        {
            return (MyInt == other.MyInt && MyDouble == other.MyDouble && MyDate == other.MyDate);
        }

        public static bool operator ==(MediumStruct c1, MediumStruct c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(MediumStruct c1, MediumStruct c2)
        {
            return !c1.Equals(c2);
        }
    }

    public sealed class MediumClass : IEquatable<MediumClass>
    {
        public DateTime MyDate;
        public double MyDouble;
        public int MyInt;

        public MediumClass(DateTime dt, double d, int i)
        {
            MyDate = dt;
            MyDouble = d;
            MyInt = i;
        }

        public static MediumClass CreateRand(Random rand)
        {
            double d = rand.NextDouble();
            int i = rand.Next(); // make this non-negative
            int year = rand.Next(1990, 2019);
            int month = rand.Next(1, 12);
            int day = rand.Next(1, 28);

            return new MediumClass(new DateTime(year, month, day), d, i);
        }

        public override int GetHashCode()
        {
            int hash = 13;

            unchecked // the code below may overflow the hash int and that will cause an exception if compiler is checking for arithmetic overflow - unchecked prevents this
            {
                hash = (hash * 7) + MyInt;
                hash = (hash * 7) + MyDouble.GetHashCode();
                hash = (hash * 7) + MyDate.GetHashCode();
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return Equals(obj as MediumClass);
        }

        public bool Equals(MediumClass other)
        {
            if (other == null)
            {
                return false;
            }

            return (MyInt == other.MyInt && MyDouble == other.MyDouble && MyDate == other.MyDate);
        }
    }

    // this should be about 40 bytes, not including the space for the actual string bytes
    public struct LargeStruct : IEquatable<LargeStruct>
    {
        public DateTime MyDate;
        public double MyDouble;
        public double MyDouble2;
        public int MyInt;
        public int MyInt2;
        public int MyInt3;
        public string MyString;

        public LargeStruct(DateTime dt, double d, double d2, int i, int i2, int i3, string s)
        {
            MyDate = dt;
            MyDouble = d;
            MyDouble2 = d2;
            MyInt = i;
            MyInt2 = i2;
            MyInt3 = i3;
            MyString = s;
        }

        public static LargeStruct CreateRand(Random rand)
        {
            double d = rand.NextDouble();
            double d2 = rand.NextDouble();
            int i = rand.Next(); // make this non-negative
            int i2 = rand.Next(); // make this non-negative
            int i3 = rand.Next(); // make this non-negative
            int year = rand.Next(1990, 2019);
            int month = rand.Next(1, 12);
            int day = rand.Next(1, 28);

            string[] strFreq = new string[] {
                StringRandUtil.UppercaseChars,
                StringRandUtil.UppercaseChars,
                StringRandUtil.LowercaseChars,
                StringRandUtil.LowercaseChars,
                StringRandUtil.Digits,
                StringRandUtil.Space,
                StringRandUtil.Symbols,
                };
            string s = StringRandUtil.CreateRandomString(rand, 10, 12, strFreq);

            return new LargeStruct(new DateTime(year, month, day), d, d2, i, i2, i3, s);
        }

        public override int GetHashCode()
        {
            int hash = 13;

            unchecked // the code below may overflow the hash int and that will cause an exception if compiler is checking for arithmetic overflow - unchecked prevents this
            {
                hash = (hash * 7) + MyInt;
                hash = (hash * 7) + MyInt2;
                hash = (hash * 7) + MyInt3;
                hash = (hash * 7) + MyDouble.GetHashCode();
                hash = (hash * 7) + MyDouble2.GetHashCode();
                hash = (hash * 7) + MyDate.GetHashCode();
                hash = (hash * 7) + MyString.GetHashCode();
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is LargeStruct))
            {
                return false;
            }

            return Equals((LargeStruct)obj);
        }

        public bool Equals(LargeStruct other)
        {
            return (MyInt == other.MyInt && MyInt2 == other.MyInt2 && MyInt3 == other.MyInt3 && MyDouble == other.MyDouble && MyDouble2 == other.MyDouble2 && MyDate == other.MyDate && MyString == other.MyString);
        }

        public static bool operator ==(LargeStruct c1, LargeStruct c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(LargeStruct c1, LargeStruct c2)
        {
            return !c1.Equals(c2);
        }
    }

    // this should be about 40 bytes, not including the space for the actual string bytes
    public sealed class LargeClass : IEquatable<LargeClass>
    {
        public DateTime MyDate;
        public double MyDouble;
        public double MyDouble2;
        public int MyInt;
        public int MyInt2;
        public int MyInt3;
        public string MyString;

        public LargeClass(DateTime dt, double d, double d2, int i, int i2, int i3, string s)
        {
            MyDate = dt;
            MyDouble = d;
            MyDouble2 = d2;
            MyInt = i;
            MyInt2 = i2;
            MyInt3 = i3;
            MyString = s;
        }

        public static LargeClass CreateRand(Random rand)
        {
            double d = rand.NextDouble();
            double d2 = rand.NextDouble();
            int i = rand.Next(); // make this non-negative
            int i2 = rand.Next(); // make this non-negative
            int i3 = rand.Next(); // make this non-negative
            int year = rand.Next(1990, 2019);
            int month = rand.Next(1, 12);
            int day = rand.Next(1, 28);

            string[] strFreq = new string[] {
                StringRandUtil.UppercaseChars,
                StringRandUtil.UppercaseChars,
                StringRandUtil.LowercaseChars,
                StringRandUtil.LowercaseChars,
                StringRandUtil.Digits,
                StringRandUtil.Space,
                StringRandUtil.Symbols,
                };
            string s = StringRandUtil.CreateRandomString(rand, 10, 12, strFreq);

            return new LargeClass(new DateTime(year, month, day), d, d2, i, i2, i3, s);
        }

        public override int GetHashCode()
        {
            int hash = 13;

            unchecked // the code below may overflow the hash int and that will cause an exception if compiler is checking for arithmetic overflow - unchecked prevents this
            {
                hash = (hash * 7) + MyInt;
                hash = (hash * 7) + MyInt2;
                hash = (hash * 7) + MyInt3;
                hash = (hash * 7) + MyDouble.GetHashCode();
                hash = (hash * 7) + MyDouble2.GetHashCode();
                hash = (hash * 7) + MyDate.GetHashCode();
                hash = (hash * 7) + MyString.GetHashCode();
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return Equals(obj as LargeClass);
        }

        public bool Equals(LargeClass other)
        {
            if (other == null)
            {
                return false;
            }

            return (MyInt == other.MyInt && MyInt2 == other.MyInt2 && MyInt3 == other.MyInt3 && MyDouble == other.MyDouble && MyDouble2 == other.MyDouble2 && MyDate == other.MyDate && MyString == other.MyString);
        }
    }

    // this should be about 64 bytes, not including the space for the actual string bytes
    public struct VeryLargeStruct : IEquatable<VeryLargeStruct>
    {
        public DateTime MyDate;
        public double MyDouble;
        public double MyDouble2;
        public int MyInt;
        public int MyInt2;
        public int MyInt3;
        public string MyString;

        public VeryLargeStruct(DateTime dt, double d, double d2, int i, int i2, int i3, string s)
        {
            MyDate = dt;
            MyDouble = d;
            MyDouble2 = d2;
            MyInt = i;
            MyInt2 = i2;
            MyInt3 = i3;
            MyString = s;
        }

        public static VeryLargeStruct CreateRand(Random rand)
        {
            double d = rand.NextDouble();
            double d2 = rand.NextDouble();
            int i = rand.Next(); // make this non-negative
            int i2 = rand.Next(); // make this non-negative
            int i3 = rand.Next(); // make this non-negative
            int year = rand.Next(1990, 2019);
            int month = rand.Next(1, 12);
            int day = rand.Next(1, 28);

            string[] strFreq = new string[] {
                StringRandUtil.UppercaseChars,
                StringRandUtil.UppercaseChars,
                StringRandUtil.LowercaseChars,
                StringRandUtil.LowercaseChars,
                StringRandUtil.Digits,
                StringRandUtil.Space,
                StringRandUtil.Symbols,
                };
            string s = StringRandUtil.CreateRandomString(rand, 10, 12, strFreq);

            return new VeryLargeStruct(new DateTime(year, month, day), d, d2, i, i2, i3, s);
        }

        public override int GetHashCode()
        {
            int hash = 13;

            unchecked // the code below may overflow the hash int and that will cause an exception if compiler is checking for arithmetic overflow - unchecked prevents this
            {
                hash = (hash * 7) + MyInt;
                hash = (hash * 7) + MyInt2;
                hash = (hash * 7) + MyInt3;
                hash = (hash * 7) + MyDouble.GetHashCode();
                hash = (hash * 7) + MyDouble2.GetHashCode();
                hash = (hash * 7) + MyDate.GetHashCode();
                hash = (hash * 7) + MyString.GetHashCode();
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is VeryLargeStruct))
            {
                return false;
            }

            return Equals((VeryLargeStruct)obj);
        }

        public bool Equals(VeryLargeStruct other)
        {
            return (MyInt == other.MyInt && MyInt2 == other.MyInt2 && MyInt3 == other.MyInt3 && MyDouble == other.MyDouble && MyDouble2 == other.MyDouble2 && MyDate == other.MyDate && MyString == other.MyString);
        }

        public static bool operator ==(VeryLargeStruct c1, VeryLargeStruct c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(VeryLargeStruct c1, VeryLargeStruct c2)
        {
            return !c1.Equals(c2);
        }
    }

    // this should be about 64 bytes, not including the space for the actual string bytes
    public sealed class VeryLargeClass : IEquatable<VeryLargeClass>
    {
        private readonly DateTime _myDate;
        private readonly double _myDouble;
        private readonly double _myDouble2;
        private readonly int _myInt;
        private readonly int _myInt2;
        private readonly int _myInt3;
        private readonly string _myString;

        public VeryLargeClass(DateTime dt, double d, double d2, int i, int i2, int i3, string s)
        {
            _myDate = dt;
            _myDouble = d;
            _myDouble2 = d2;
            _myInt = i;
            _myInt2 = i2;
            _myInt3 = i3;
            _myString = s;
        }

        public static VeryLargeClass CreateRand(Random rand)
        {
            double d = rand.NextDouble();
            double d2 = rand.NextDouble();
            int i = rand.Next(); // make this non-negative
            int i2 = rand.Next(); // make this non-negative
            int i3 = rand.Next(); // make this non-negative
            int year = rand.Next(1990, 2019);
            int month = rand.Next(1, 12);
            int day = rand.Next(1, 28);

            string[] strFreq = new string[] {
                StringRandUtil.UppercaseChars,
                StringRandUtil.UppercaseChars,
                StringRandUtil.LowercaseChars,
                StringRandUtil.LowercaseChars,
                StringRandUtil.Digits,
                StringRandUtil.Space,
                StringRandUtil.Symbols,
                };
            string s = StringRandUtil.CreateRandomString(rand, 10, 12, strFreq);

            return new VeryLargeClass(new DateTime(year, month, day), d, d2, i, i2, i3, s);
        }

        public override int GetHashCode()
        {
            int hash = 13;

            unchecked // the code below may overflow the hash int and that will cause an exception if compiler is checking for arithmetic overflow - unchecked prevents this
            {
                hash = (hash * 7) + _myInt;
                hash = (hash * 7) + _myInt2;
                hash = (hash * 7) + _myInt3;
                hash = (hash * 7) + _myDouble.GetHashCode();
                hash = (hash * 7) + _myDouble2.GetHashCode();
                hash = (hash * 7) + _myDate.GetHashCode();
                hash = (hash * 7) + _myString.GetHashCode();
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return Equals(obj as VeryLargeClass);
        }

        public bool Equals(VeryLargeClass other)
        {
            if (other == null)
            {
                return false;
            }

            return (_myInt == other._myInt && _myInt2 == other._myInt2 && _myInt3 == other._myInt3 && _myDouble == other._myDouble && _myDouble2 == other._myDouble2 && _myDate == other._myDate && _myString == other._myString);
        }
    }
}
