namespace MyLibrary;

public class After2
{
    private const int MinimumVotingAge = 18;

    public bool IsEligibleForVoting(int age)
    {
        return age >= MinimumVotingAge;
    }
}
