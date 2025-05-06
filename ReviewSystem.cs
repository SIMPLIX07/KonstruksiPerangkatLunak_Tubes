using System;

public abstract class ReviewSystem
{
    protected int rating;
    protected string review;

    public ReviewSystem(int rating, string ulasan)
    {
        if (rating < 1 || rating > 5)
        {
            throw new ArgumentException("Rating harus antara 1-5.");
        }
        this.rating = rating;
        this.review = ulasan ?? "Tidak ada ulasan.";
    }

    public int GetRating()
    {
        return rating;
    }

    public string GetUlasan()
    {
        return review;
    }

    public override string ToString()
    {
        return "Ulasan: " + this.review + " dengan rating: " + this.rating + "/5.";
    }
}
