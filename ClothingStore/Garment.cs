namespace ClothingStore
{
    struct Garment
    {
        public Item Type { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
        public Collection Season { get; set; }
        public decimal Price { get; set; }
    }

    //enums under heere
    public enum Item
    {
        None = 0,
        Shirt = 1,
        Blouse = 2,
        Coat = 3,
        Dress = 4,
        Jeans = 5,
        Shorts = 6,


        Belt = 11,
        Gloves = 12,
        Cap = 13,
        Hat = 14,
            

        Shoes = 111

    }
    public enum Size
    {
        None,
        XS,
        S,
        M,
        L,
        XL,
        XXL
    }
    public enum Color
    {
        None,
        White,
        Grey,
        Black,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple,
        Red
    }
    public enum Collection
    {
        None,
        Winter,
        Spring,
        Summer,
        Autumn
    }
}

