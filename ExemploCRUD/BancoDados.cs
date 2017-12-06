using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace ExemploCRUD
{
    public class BancoDados
    {
        SqlConnection cn;
        SqlCommand cd;
        SqlDataReader dr;

        public bool Add(Categoria cat)
        {
            bool retorno = false;
            try
            {
                cn= new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress; Initial Catalog=Papelaria;
                User ID= sa; Password= senai@123"; //Local do banco de dados
                cn.Open();
                cd = new SqlCommand();
                cd.Connection = cn; //Local onde os comandos de SQL devem ser executados

                cd.CommandType = CommandType.Text;
                cd.CommandText = "Insert into categorias(titulo)values(@vt)";
                cd.Parameters.AddWithValue("@vt", cat.Titulo);

                int r = cd.ExecuteNonQuery();

                if (r > 0)
                    retorno = true;

                cd.Parameters.Clear();
            }
            catch(SqlException se)
            {
                throw new Exception("Erro ao tentar cadastrar. "+se.Message); //Caso não ocorra o cadastro o programa imprime uma mensagem de erro.
            }
            catch(Exception ex)
            {
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return retorno;
        }

        public bool Update(Categoria cat)
        {
            bool retorno = false;
            try
            {
                cn= new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress; Initial Catalog=Papelaria;
                User ID= sa; Password= senai@123"; //Local do banco de dados
                cn.Open();
                cd = new SqlCommand();
                cd.Connection = cn; //Local onde os comandos de SQL devem ser executados

                cd.CommandType = CommandType.Text;
                cd.CommandText = "update categorias set titulo= @vt where idcategoria=@vi"; //Linha que mudou em relação ao ADD
                cd.Parameters.AddWithValue("@vt", cat.Titulo);
                cd.Parameters.AddWithValue("@vi", cat.idCategoria); //Linha que mudou em relação ao ADD

                int r = cd.ExecuteNonQuery();

                if (r > 0)
                    retorno = true;

                cd.Parameters.Clear();
            }
            catch(SqlException se)
            {
                throw new Exception("Erro ao tentar atualizar. "+se.Message); //Caso não ocorra o cadastro o programa imprime uma mensagem de erro.
            }
            catch(Exception ex)
            {
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return retorno;
        }
        
        public bool Delete(Categoria cat)
        {
            bool retorno = false;
            try
            {
                cn= new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress; Initial Catalog=Papelaria;
                User ID= sa; Password= senai@123"; //Local do banco de dados
                cn.Open();
                cd = new SqlCommand();
                cd.Connection = cn; //Local onde os comandos de SQL devem ser executados

                cd.CommandType = CommandType.Text;
                cd.CommandText = "delete from categorias where idcategoria=@vi"; //Linha que mudou em relação ao ADD
                cd.Parameters.AddWithValue("@vi", cat.idCategoria); //Linha que mudou em relação ao ADD

                int r = cd.ExecuteNonQuery();

                if (r > 0)
                    retorno = true;

                cd.Parameters.Clear();
            }
            catch(SqlException se)
            {
                throw new Exception("Erro ao tentar deletar. "+se.Message); //Caso não ocorra o cadastro o programa imprime uma mensagem de erro.
            }
            catch(Exception ex)
            {
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return retorno;
        }

        public List<Categoria> ListarCategorias(int id)
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                cn= new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress; Initial Catalog=Papelaria;
                User ID= sa; Password= senai@123"; //Local do banco de dados
                cn.Open();
                cd = new SqlCommand();
                cd.Connection = cn; //Local onde os comandos de SQL devem ser executados
                cd.CommandType = CommandType.Text;
                cd.CommandText = "select * from categorias where idcategoria=@vi";
                cd.Parameters.AddWithValue("@vi", id);

                dr = cd.ExecuteReader(); //Leitor de dados

                while(dr.Read())
                {
                    Categoria ct= new Categoria
                    {
                        idCategoria=dr.GetInt32(0), //Colocando os dados recebidos em (dr) organizando-os na (lista)
                        Titulo=dr.GetString(1)
                    };
                    lista.Add(ct); 
                }
                cd.Parameters.Clear();
            }
            catch(SqlException se)
            {
                throw new Exception("Erro ao tentar listar."+se.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro inesperado"+ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }
        public List<Categoria> ListarCategorias(string titulo)
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                cn= new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress; Initial Catalog=Papelaria;
                User ID= sa; Password= senai@123"; //Local do banco de dados
                cn.Open();
                cd = new SqlCommand();
                cd.Connection = cn; //Local onde os comandos de SQL devem ser executados
                cd.CommandType = CommandType.Text;
                cd.CommandText = "select * from categorias where titulo like @vt";
                cd.Parameters.AddWithValue("@vt", titulo);

                dr = cd.ExecuteReader(); //Leitor de dados

                while(dr.Read())
                {
                    Categoria ct= new Categoria
                    {
                        idCategoria=dr.GetInt32(0), //Colocando os dados recebidos em (dr) organizando-os na (lista)
                        Titulo=dr.GetString(1)
                    };
                    lista.Add(ct); 
                }
                cd.Parameters.Clear();
            }
            catch(SqlException se)
            {
                throw new Exception("Erro ao tentar listar."+se.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro inesperado"+ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

    }
}