﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DCCScore.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DCCScoreDbEntities : DbContext
    {
        public DCCScoreDbEntities()
            : base("name=DCCScoreDbEntities")
        {
    		Database.SetInitializer<DCCScoreDbEntities>(null);
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    	public virtual void Commit()
        {
    		base.SaveChanges();
    	}
    
        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Avaliaco> Avaliacoes { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Disciplina> Disciplinas { get; set; }
        public virtual DbSet<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
        public virtual DbSet<Professore> Professores { get; set; }
        public virtual DbSet<Parametro> Parametros { get; set; }
    }
}
