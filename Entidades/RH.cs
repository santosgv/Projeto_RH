using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Projeto_RH.Enums;


namespace Projeto_RH.Entidades
{
    [Table("RH")]

    public class Rh
    {
        public Rh()
        {
            DataCadastro = DateTime.Now;
    
        }

        [Key]
        [Display(Name = "N° requisicao")]
        [Column("id")]
        public int id { get; set; }

        [Display(Name = "Aberto Em")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Adicione a referencia Pandape")]
        [StringLength(50, ErrorMessage = "A referencia nao pode ter mais que 50 characters.")]
        [Display(Name = "Pandape")]
        [Column("N_Referencia_Pandape")]
        public string N_Referencia_Pandape { get; set; }

        [Required(ErrorMessage = "Selecione o Tipo de Vaga")]
        [Display(Name = "vaga")]
        [Column("Tipo_de_vaga")]

        public Vaga Vaga { get; set; }

        [Required(ErrorMessage = "E necessario um email Valido Patrus")]
        [Display(Name = "Email")]
        [Column("Email_Solicitante")]
        public string Email_Solicitante { get; set; }

        [Required(ErrorMessage = "Selecione a Filial")]
        [Display(Name = "Filial")]
        [Column("Filial_RH")]

        public Filial EnumFiliais { get; set; }

        [Display(Name = "Infra")]
        [Column("Solicitação_Infra")]

        public Status Solicitação_Infra { get; set; }

        [Display(Name = "Telefonia")]
        [Column("Solicitação_Telefonia")]
        public Status Solicitação_Telefonia { get; set; }

        [Display(Name = "Equipamento")]
        [Column("Tipo_Equipamento")]
        public Equipamento Tipo_Equipamento { get; set; }

        [Required(ErrorMessage = "Adicione um Cargo")]
        [StringLength(50, ErrorMessage = "O Cargo nao pode ter mais que 50 characters.")]
        [Display(Name = "Cargo")]
        [Column("Cargo")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Adicione um Setor")]
        [StringLength(50, ErrorMessage = "O Setor nao pode ter mais que 50 characters.")]
        [Display(Name = "Setor")]
        [Column("Setor")]
        public string Setor { get; set; }

        [Required(ErrorMessage = "Adicione uma Filial Ti")]
        [Display(Name = "Filial TI")]
        [Column("Filial_infra")]
        public Filial Filial_infra { get; set; }

        [Display(Name = "Movidesk Infra")]
        [Column("Movidesk_Infra")]
        public string Movidesk_Infra { get; set; }

        [Display(Name = "Movidesk Telefonia")]
        [Column("Movidesk_Telefonia")]
        public string Movidesk_Telefonia { get; set; }


        [Display(Name = "Andamento")]
        [Column("Andamento")]

        public Andamento Andamento { get; set; }


        [Display(Name = "Recebido Por")]
        [Column("Recebido_por")]
        public string Recebido_por { get; set; }

        [Display(Name = "Data Recebimento")]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        [Column("DataRecebimento")]
        public DateTime DataRecebimento { get; set; }

        [Display(Name = "Serie equipamento")]
        [Column("Serie_equipamento")]
        public string Serie_equipamento { get; set; }

    }
}
