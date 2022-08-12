namespace Level.Blocks
{
    public interface IBlockPool
    {
        BaseBlockView Get();

        void Return(BaseBlockView blockView);
        public void DeactivationAllObject();
    }
}