namespace Code.Controllers.CardSystem
{
    public interface ICardPlayingController: IClean
    {
        public void GetNewCards();
        public void Activate();
        public void Deactivate();
    }
}