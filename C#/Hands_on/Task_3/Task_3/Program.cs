using System;


namespace hands_on

{
    class Billing
    {
        public static void FinalAmount()
        {
            int qty = 5;
            float unitprice = 200f;
            float total = qty * unitprice;  //5*200
            float discount = total * 0.10f; //discount 10 percent 
            float finalamount = total - discount;

            Console.WriteLine("****billing****");
            Console.WriteLine($"Totalprice=rupees{total}");
            Console.WriteLine($"Discount=rupees{discount}");
            Console.WriteLine($"Final Amount=rupees{finalamount}");
            Console.WriteLine();
        }
    }
    //2.Operator Overloading
    class Box
    {
        public double Length { get; set; }
        public Box(double length)
        {
            Length = length;
        }
        public static Box operator +(Box b1, Box b2)
        {
            return new Box(b1.Length + b2.Length);
        }
        public void Show()
        {
            Console.WriteLine($"Box.Length:{Length}");

        }
    }
    //3.Player Score
    class Player : IComparable<Player>
    {
        public int Score { get; set; }

        public Player(int score)
        {
            Score = score;
        }

        public static bool operator ==(Player p1, Player p2) => p1.Score == p2.Score;
        public static bool operator !=(Player p1, Player p2) => !(p1 == p2);

        public override bool Equals(object obj)
        {
            return obj is Player other && this.Score == other.Score;
        }

        public override int GetHashCode() => Score.GetHashCode();

        public int CompareTo(Player other)
        {
            return this.Score.CompareTo(other.Score);
        }
    }

    /// Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Billing
            Billing.FinalAmount();

            // Overload
            Console.WriteLine("****Box Addition*****");
            Box b1 = new Box(8.9);
            Box b2 = new Box(7.5);
            Box result = b1 + b2;
            result.Show();
            Console.WriteLine();

            // Player Comparison
            Console.WriteLine("***Player Score****");
            Player p1 = new Player(100);
            Player p2 = new Player(100);
            Player p3 = new Player(200);

            Console.WriteLine($"p1 == p2: {p1 == p2}");
            Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
            Console.WriteLine($"p1.CompareTo(p3): {p1.CompareTo(p3)}"); // -1 means p1 < p3
            Console.WriteLine($"p3.CompareTo(p1): {p3.CompareTo(p1)}"); // 1 means p3 > p1

            Console.Read();
        }
    }
}
