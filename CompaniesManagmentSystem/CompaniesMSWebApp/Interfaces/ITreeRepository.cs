
public interface ITreeRepository<T>
{
    //IEnumerable<T> GetList(); // получение всех объектов
    T Get(int id); // получение одного объекта по id
    void AddChild(T parent, T item);
    void Create(T item); // создание объекта
    void Update(T item); // обновление объекта
    void Delete(int id); // удаление объекта по id
}