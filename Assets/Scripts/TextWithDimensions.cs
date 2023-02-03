public struct TextWithDimensions
{
    public int width;
    public int height;
    public string formattedText;

    public TextWithDimensions(int width_, int height_, string text_)
    {
        width = width_;    
        height = height_;
        formattedText = text_;
    }

    public override string ToString()
    {
        return "(" + width + ", " + height + ", " + formattedText + " )";
    }
}