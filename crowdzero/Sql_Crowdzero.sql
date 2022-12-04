/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     28/02/2021 16:42:18                          */
/*==============================================================*/

if exists (select 1
            from  sysobjects
           where  id = object_id('VOLUNTARIOS')
            and   type = 'U')
   drop table VOLUNTARIOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SUGESTOES')
            and   type = 'U')
   drop table SUGESTOES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('REPORT_LIMPEZA')
            and   type = 'U')
   drop table REPORT_LIMPEZA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RECEBE')
            and   type = 'U')
   drop table RECEBE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('POSSUI')
            and   type = 'U')
   drop table POSSUI
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FUNCIONARIOS_CMV')
            and   type = 'U')
   drop table FUNCIONARIOS_CMV
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FEEDBACK')
            and   type = 'U')
   drop table FEEDBACK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ESTADO')
            and   type = 'U')
   drop table ESTADO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EQUIPA_LIMPEZA')
            and   type = 'U')
   drop table EQUIPA_LIMPEZA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ATIVAR_INATIVAR')
            and   type = 'U')
   drop table ATIVAR_INATIVAR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('REPORT')
            and   type = 'U')
   drop table REPORT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ESTADO_POPULACIONAL')
            and   type = 'U')
   drop table ESTADO_POPULACIONAL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOCAIS')
            and   type = 'U')
   drop table LOCAIS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('APP')
            and   type = 'U')
   drop table APP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AVATAR')
            and   type = 'U')
   drop table AVATAR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRADOR')
            and   type = 'U')
   drop table ADMINISTRADOR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BACK_OFFICE')
            and   type = 'U')
   drop table BACK_OFFICE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UTILIZADORES')
            and   type = 'U')
   drop table UTILIZADORES
go



/*==============================================================*/
/* Table: UTILIZADORES                                          */
/*==============================================================*/
create table UTILIZADORES (
   N_UTILIZADOR         int             IDENTITY(1,1)     not null,
   NOME                 varchar(200)         not null,
   TIPO_UTILIZADOR      varchar(50)          not null,
   IDADE                int                  null,
   GENERO               varchar(10)          null,
   TELEFONE             char(9)              not null,
   BI                   int                  not null,
   EMAIL                varchar(50)          not null,
   PASSWORD             varchar(20)          not null,
   ESTADO               varchar(8)           not null,
   constraint PK_UTILIZADORES primary key nonclustered (N_UTILIZADOR)
)
go

/*==============================================================*/
/* Table: BACK_OFFICE                                           */
/*==============================================================*/
create table BACK_OFFICE (
   N_UTILIZADOR         int                   not null,
   N_BACK               int                  IDENTITY(1,1) not null,
   TIPO_BACKO           varchar(30)          not null,
   DATA_ADMISSAO        datetime             not null,
   ESTADO               varchar(8)           not null,
   constraint PK_BACK_OFFICE primary key nonclustered (N_UTILIZADOR, N_BACK),
   constraint FK_BACK_OFF_TIPO2_UTILIZAD foreign key (N_UTILIZADOR)
      references UTILIZADORES (N_UTILIZADOR)
)
go

/*==============================================================*/
/* Table: ADMINISTRADOR                                         */
/*==============================================================*/
create table ADMINISTRADOR (
   N_UTILIZADOR         int                   not null,
   N_BACK               int                  not null,
   N_ADMIN              int                  IDENTITY(1,1) not null,
   CARGO                varchar(20)          not null,
   constraint PK_ADMINISTRADOR primary key nonclustered (N_UTILIZADOR, N_BACK, N_ADMIN),
   constraint FK_ADMINIST__4_BACK_OFF foreign key (N_UTILIZADOR, N_BACK)
      references BACK_OFFICE (N_UTILIZADOR, N_BACK)
)
go

/*==============================================================*/
/* Table: AVATAR                                                */
/*==============================================================*/
create table AVATAR (
   N_AVATAR             int                  IDENTITY(1,1) not null,
   NIVEL                int                  not null,
   PONTOS               int                  null,
   constraint PK_AVATAR primary key nonclustered (N_AVATAR)
)
go

/*==============================================================*/
/* Table: APP                                                   */
/*==============================================================*/
create table APP (
   N_UTILIZADOR         int                   not null,
   N_APP                int                  IDENTITY(1,1) not null,
   N_AVATAR             int                  null,
   DATA_ADMISSAO        datetime             not null,
   RANKING              varchar(200)         not null,
   ESTADO               varchar(8)           not null,
   constraint PK_APP primary key nonclustered (N_UTILIZADOR, N_APP),
   constraint FK_APP_POSSUEM_AVATAR foreign key (N_AVATAR)
      references AVATAR (N_AVATAR),
   constraint FK_APP_TIPO_UTILIZAD foreign key (N_UTILIZADOR)
      references UTILIZADORES (N_UTILIZADOR)
)
go

/*==============================================================*/
/* Table: LOCAIS                                                */
/*==============================================================*/
create table LOCAIS (
   N_LOCAL              int                  IDENTITY(1,1) not null,
   N_UTILIZADOR         int                  null,
   N_BACK               int                  null,
   N_ADMIN              int                  null,
   NOME_LOCAL           varchar(50)          not null,
   LOCALIZACAO          varchar(200)         not null,
   PIN                  image                not null,
   ESTADO               varchar(8)           not null,
   constraint PK_LOCAIS primary key nonclustered (N_LOCAL),
   constraint FK_LOCAIS_ADICIONA_ADMINIST foreign key (N_UTILIZADOR, N_BACK, N_ADMIN)
      references ADMINISTRADOR (N_UTILIZADOR, N_BACK, N_ADMIN)
)
go

/*==============================================================*/
/* Table: ESTADO_POPULACIONAL                                   */
/*==============================================================*/
create table ESTADO_POPULACIONAL (
   N_ESTADO_POP         int                  IDENTITY(1,1) not null,
   DENSIDADE            varchar(20)          not null,
   DATA                 datetime             not null,
   HORA                 datetime             not null,
   TIPO                 varchar(50)          not null,
   ESTADO               varchar(8)           not null,
   constraint PK_ESTADO_POPULACIONAL primary key nonclustered (N_ESTADO_POP)
)
go

/*==============================================================*/
/* Table: REPORT                                                */
/*==============================================================*/
create table REPORT (
   N_REPORT             int                  IDENTITY(1,1) not null,
   N_UTILIZADOR         int                  null,
   N_LOCAL              int                  null,
   N_ESTADO_POP         int                  null,
   DATA                 datetime             not null,
   HORA                 datetime             not null,
   DENSIDADE            varchar(20)          not null,
   ESTADO               varchar(8)           not null,
   constraint PK_REPORT primary key nonclustered (N_REPORT),
   constraint FK_REPORT_RECEBER_LOCAIS foreign key (N_LOCAL)
      references LOCAIS (N_LOCAL),
   constraint FK_REPORT_INCLUI_ESTADO_P foreign key (N_ESTADO_POP)
      references ESTADO_POPULACIONAL (N_ESTADO_POP),
   constraint FK_REPORT_REALIZAM_UTILIZAD foreign key (N_UTILIZADOR)
      references UTILIZADORES (N_UTILIZADOR)
)
go

/*==============================================================*/
/* Table: ATIVAR_INATIVAR                                       */
/*==============================================================*/
create table ATIVAR_INATIVAR (
   N_REPORT             int                  not null,
   N_UTILIZADOR         int                  not null,
   N_BACK               int                  not null,
   constraint PK_ATIVAR_INATIVAR primary key (N_REPORT, N_UTILIZADOR, N_BACK),
   constraint FK_ATIVAR_I_ATIVAR_IN_REPORT foreign key (N_REPORT)
      references REPORT (N_REPORT),
   constraint FK_ATIVAR_I_ATIVAR_IN_BACK_OFF foreign key (N_UTILIZADOR, N_BACK)
      references BACK_OFFICE (N_UTILIZADOR, N_BACK)
)
go

/*==============================================================*/
/* Table: EQUIPA_LIMPEZA                                        */
/*==============================================================*/
create table EQUIPA_LIMPEZA (
   N_UTILIZADOR         int                  not null,
   N_EQUIPA             int                  IDENTITY(1,1) not null,
   LOCALIZACAO          varchar(200)         not null,
   DISPONIBILIDADE      varchar(50)          not null,
   AGENDA               varchar(100)         null,
   constraint PK_EQUIPA_LIMPEZA primary key nonclustered (N_UTILIZADOR, N_EQUIPA),
   constraint FK_EQUIPA_L_TIPO3_UTILIZAD foreign key (N_UTILIZADOR)
      references UTILIZADORES (N_UTILIZADOR)
)
go

/*==============================================================*/
/* Table: ESTADO                                                */
/*==============================================================*/
create table ESTADO (
   N_ESTADO             int                  IDENTITY(1,1) not null,
   TIPO                 varchar(50)          not null,
   DATA                 datetime             not null,
   HORA                 datetime             not null,
   constraint PK_ESTADO primary key nonclustered (N_ESTADO)
)
go

/*==============================================================*/
/* Table: FEEDBACK                                              */
/*==============================================================*/
create table FEEDBACK (
   N_FEEDBACK           int                  IDENTITY(1,1) not null,
   N_UTILIZADOR         int                  null,
   DATA                 datetime             not null,
   HORA                 datetime             not null,
   TIPO_FEEDBACK        char(7)              not null,
   constraint PK_FEEDBACK primary key nonclustered (N_FEEDBACK),
   constraint FK_FEEDBACK_EFETUAM_UTILIZAD foreign key (N_UTILIZADOR)
      references UTILIZADORES (N_UTILIZADOR)
)
go

/*==============================================================*/
/* Table: FUNCIONARIOS_CMV                                      */
/*==============================================================*/
create table FUNCIONARIOS_CMV (
   N_UTILIZADOR         int                   not null,
   N_BACK               int                  not null,
   N_FUNC               int                  IDENTITY(1,1) not null,
   CARGO                varchar(20)          not null,
   constraint PK_FUNCIONARIOS_CMV primary key nonclustered (N_UTILIZADOR, N_BACK, N_FUNC),
   constraint FK_FUNCIONA__2_BACK_OFF foreign key (N_UTILIZADOR, N_BACK)
      references BACK_OFFICE (N_UTILIZADOR, N_BACK)
)
go

/*==============================================================*/
/* Table: POSSUI                                                */
/*==============================================================*/
create table POSSUI (
   N_LOCAL              int                  not null,
   N_ESTADO_POP         int                  not null,
   constraint PK_POSSUI primary key (N_LOCAL, N_ESTADO_POP),
   constraint FK_POSSUI_POSSUI_LOCAIS foreign key (N_LOCAL)
      references LOCAIS (N_LOCAL),
   constraint FK_POSSUI_POSSUI2_ESTADO_P foreign key (N_ESTADO_POP)
      references ESTADO_POPULACIONAL (N_ESTADO_POP)
)
go

/*==============================================================*/
/* Table: RECEBE                                                */
/*==============================================================*/
create table RECEBE (
   N_FEEDBACK           int                  not null,
   N_REPORT             int                  not null,
   constraint PK_RECEBE primary key (N_FEEDBACK, N_REPORT),
   constraint FK_RECEBE_RECEBE_FEEDBACK foreign key (N_FEEDBACK)
      references FEEDBACK (N_FEEDBACK),
   constraint FK_RECEBE_RECEBE2_REPORT foreign key (N_REPORT)
      references REPORT (N_REPORT)
)
go

/*==============================================================*/
/* Table: REPORT_LIMPEZA                                        */
/*==============================================================*/
create table REPORT_LIMPEZA (
   N_EQUI_REPORT        int          IDENTITY(1,1) not null,
   N_LOCAL              int                  not null,
   N_ESTADO             int                  not null,
   N_UTILIZADOR         int                  not null,
   N_EQUIPA             int                  not null,
   DATA                 datetime             not null,
   HORA                 datetime             null,
   LOCAL                varchar(50)          null,
   constraint PK_REPORT_LIMPEZA primary key nonclustered (N_EQUI_REPORT),
   constraint FK_REPORT_L____LOCAIS foreign key (N_LOCAL)
      references LOCAIS (N_LOCAL),
   constraint FK_REPORT_L___EQUIPA_L foreign key (N_UTILIZADOR, N_EQUIPA)
      references EQUIPA_LIMPEZA (N_UTILIZADOR, N_EQUIPA),
   constraint FK_REPORT_L_RELATIONS_ESTADO foreign key (N_ESTADO)
      references ESTADO (N_ESTADO)
)
go

/*==============================================================*/
/* Table: SUGESTOES                                             */
/*==============================================================*/
create table SUGESTOES (
   N_SUG                int                 IDENTITY(1,1) not null,
   ADM_N_UTILIZADOR     int                  null,
   N_BACK               int                  null,
   N_ADMIN              int                  null,
   N_UTILIZADOR         int                  null,
   TIPO                 varchar(50)          not null,
   DATA                 datetime             not null,
   DESCRICAO            varchar(200)         not null,
   VALIDACAO            varchar(8)           not null,
   constraint PK_SUGESTOES primary key nonclustered (N_SUG),
   constraint FK_SUGESTOE_FAZEM_UTILIZAD foreign key (N_UTILIZADOR)
      references UTILIZADORES (N_UTILIZADOR),
   constraint FK_SUGESTOE_AVALIA_ADMINIST foreign key (ADM_N_UTILIZADOR, N_BACK, N_ADMIN)
      references ADMINISTRADOR (N_UTILIZADOR, N_BACK, N_ADMIN)
)
go

/*==============================================================*/
/* Table: VOLUNTARIOS                                           */
/*==============================================================*/
create table VOLUNTARIOS (
   N_UTILIZADOR         int                   not null,
   N_BACK               int                  not null,
   N_VOL                int                  IDENTITY(1,1) not null,
   constraint PK_VOLUNTARIOS primary key nonclustered (N_UTILIZADOR, N_BACK, N_VOL),
   constraint FK_VOLUNTAR__3_BACK_OFF foreign key (N_UTILIZADOR, N_BACK)
      references BACK_OFFICE (N_UTILIZADOR, N_BACK)
)
go

