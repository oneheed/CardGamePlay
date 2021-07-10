namespace CardGamePlay.Shared.Interfaces
{
    public interface IGameplay
    {
        int[] Shuffle(int times = 1);

        int[][] Draw(int[] cards, int user);
    }
}
