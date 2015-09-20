namespace Visitor
{
    public interface IElementsGroup
    {
        void Add(IElement element);
        void Remove(IElement element);
        void Accept(IVisitor visitor);
    }
}
