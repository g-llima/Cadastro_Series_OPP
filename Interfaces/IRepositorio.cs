public interface IRepositorio<T>
{
    List<T> Lista();
    T RetornarPorId(int id);
    void Inserir(T entidade);
    void Excluir(int id);
    void Atualizar(int id, T entidade);
    int ProximoId();
}