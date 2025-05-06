using System;

public class FreelancerReview : ReviewSystem
{
    private string clientName;

    public FreelancerReview(int rating, string review, string clientName) : base(rating, review)
    {
        this.clientName = clientName;
    }

    public void DisplayReview()
    {
        Console.WriteLine("Review dari Freelancer untuk Klien: " + clientName);
        Console.WriteLine("Rating: " + rating + "/5");
        Console.WriteLine("Ulasan: " + review);
    }

    public string GetClientName()
    {
        return clientName;
    }
}
