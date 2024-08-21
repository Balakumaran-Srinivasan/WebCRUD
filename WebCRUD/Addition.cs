namespace WebCRUD
{
    public class Addition : IAddition
    {
        public int a {  get; set; }
        public int b { get; set; }

        public int AddTwoNumber(int a, int b)
        {

            return a + b;
        }


    }

}

