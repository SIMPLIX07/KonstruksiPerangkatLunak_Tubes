using System;

public class ClientReview : ReviewSystem
{
    private string freelancerName;

    public ClientReview(int rating, string review, string freelancerName) : base(rating, review)
    {
        this.freelancerName = freelancerName;
    }

    public void displayReview()
    {
        Console.WriteLine("Review dari Klien untuk Freelancer: " + freelancerName);
        Console.WriteLine("Rating: " + rating + "/5");
        Console.WriteLine("Ulasan: " + review);
    }

    public string getFreelancerName()
    {
        return freelancerName;
    }
}
