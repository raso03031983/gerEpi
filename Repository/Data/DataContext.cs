using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Centro_Custo> Centro_Custos { get; set; }
    public DbSet<Classificacao> Classificacoes { get; set; }
    public DbSet<Divisao> Divisoes { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Entrada> Entradas { get; set; }
    public DbSet<Entrega_Mobile> Entregas_Mobile { get; set; }
    public DbSet<EPI_Entregue> EPI_Entregues { get; set; }
    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<Familia> Familias { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Grade_Tamanho> Grade_Tamanhos { get; set; }
    public DbSet<GSE> GSEs { get; set; }
    public DbSet<GSE_CargoLocal> GSE_CargoLocais { get; set; }
    public DbSet<GSE_Classificacao> GSE_Classificacoes { get; set; }
    public DbSet<Integrante> Integrantes { get; set; }
    public DbSet<Integrante_Biometria> Integrantes_Biometria { get; set; }
    public DbSet<Integrante_Mobile> Integrantes_Mobile { get; set; }
    public DbSet<Local> Locais { get; set; }
    public DbSet<Local_Entrega> Local_Entregas { get; set; }
    public DbSet<Log_Integrante> Log_Integrantes { get; set; }
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Mobile> Mobiles { get; set; }
    public DbSet<Motivo_Trocas> Motivo_Trocas { get; set; }
    public DbSet<Nota_Entrada> Nota_Entradas { get; set; }
    public DbSet<Nota_EntradaDetalhes> Nota_EntradaDetalhes { get; set; }
    public DbSet<Saidas> Saidas { get; set; }
    public DbSet<Saldo> Saldos { get; set; }
    public DbSet<SubEquipamento> SubEquipamentos { get; set; }
    public DbSet<Tipo_Operacoes> Tipo_Operacoes { get; set; }

  }
}