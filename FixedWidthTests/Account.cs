namespace FixedWidth.Tests
{

    [TextSerializable]
    public class AccountClass
    {
        
        [TextField(1, 1)]
        public char Type { get; set; }

        [TextField(2, 8, Padding = 'X')]
        public string Number { get; set; }

        [TextField(10, 10, Padding = '0')]
        public decimal Balance { get; set; }

        [TextField(20, 20)]
        public string Name { get; set; }

        [TextField(40, 2)]
        public int Status { get; set; }

    }

}
