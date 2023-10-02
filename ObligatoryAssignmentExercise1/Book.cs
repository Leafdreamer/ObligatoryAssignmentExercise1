namespace ObligatoryAssignmentExercise1
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public double Price { get; set; }

        public Book(int id, string? title, double price) 
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public void ValidateId()
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative or zero.");
            }
            return;
        }

        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException("Title string is null.");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException("Title string must be minimum 3 characters.");
            }
            return;
        }

        public void ValidatePrice()
        {
            if (Price < 0 || Price > 1200)
            {
                throw new ArgumentOutOfRangeException("Invalid price. Should be between 0 and 1200.");
            }
            return;
        }

        public void Validate()
        {
            try
            {
                ValidateId();
                ValidateTitle();
                ValidatePrice();
                Console.WriteLine("Works!");
            }
            catch (ArgumentOutOfRangeException aex)
            {
                Console.WriteLine(aex.Message);
            }
            catch (ArgumentNullException aex)
            {
                Console.WriteLine(aex.Message);
            }
            catch (ArgumentException aex) 
            {
                Console.WriteLine(aex.Message);
            }
        }
    }
}