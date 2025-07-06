namespace ConcessionLibrary
{
    public class ConcessionCalculator
    {
        public static string CalculateConcession(string name, int age, double totalFare)
        {
            if (age <= 5)
            {
                return $"{name} - Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double discountedFare = totalFare * 0.7;
                return $"{name} - Senior Citizen - Fare after 30% concession: ₹{discountedFare}";
            }
            else
            {
                return $"{name} - Ticket Booked - Fare: ₹{totalFare}";
            }
        }
    }
}
