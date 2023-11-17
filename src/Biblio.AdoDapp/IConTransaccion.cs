using System.Data;

namespace Biblio.AdoDapp;
public interface IConTransaccion
{
    public IDbTransaction Transaccion { get;}
}