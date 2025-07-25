CREATE SCHEMA IF NOT EXISTS "public";

CREATE SEQUENCE "public".faculte_id_seq AS integer START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".mention_id_seq AS integer START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".option_id_seq AS integer START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".parcours_id_seq AS integer START WITH 1 INCREMENT BY 1;

CREATE  TABLE "public".faculte ( 
	id                   serial  NOT NULL  ,
	nom_faculte          varchar(100)    ,
	CONSTRAINT faculte_pkey PRIMARY KEY ( id )
 );

CREATE  TABLE "public".mention ( 
	id                   serial  NOT NULL  ,
	id_faculte           integer    ,
	nom_mention          varchar(100)    ,
	CONSTRAINT mention_pkey PRIMARY KEY ( id ),
	CONSTRAINT mention_id_faculte_fkey FOREIGN KEY ( id_faculte ) REFERENCES "public".faculte( id ) ON DELETE CASCADE ON UPDATE CASCADE 
 );

CREATE  TABLE "public"."option" ( 
	id                   serial  NOT NULL  ,
	nom                  varchar(5)  NOT NULL  ,
	CONSTRAINT option_pkey PRIMARY KEY ( id )
 );

CREATE  TABLE "public".parcours ( 
	id                   serial  NOT NULL  ,
	id_mention           integer    ,
	nom_parcours         varchar(100)    ,
	CONSTRAINT parcours_pkey PRIMARY KEY ( id ),
	CONSTRAINT parcours_id_mention_fkey FOREIGN KEY ( id_mention ) REFERENCES "public".mention( id ) ON DELETE CASCADE ON UPDATE CASCADE 
 );

CREATE  TABLE "public".preinscription ( 
	num_bacc             integer  NOT NULL  ,
	annee_bacc           integer  NOT NULL  ,
	nom_prenoms          varchar(255)    ,
	email                text    ,
	tel                  varchar(100)    ,
	recu_bancaire        varchar(100)  NOT NULL  ,
	id_parcours          integer    ,
	chemin_preuve_paiement text    ,
	est_valide           boolean DEFAULT false   ,
	date_preinscription  date DEFAULT CURRENT_DATE   ,
	id_option            integer  NOT NULL  ,
	CONSTRAINT preinscription_pkey PRIMARY KEY ( num_bacc, annee_bacc ),
	CONSTRAINT preinscription_tel_key UNIQUE ( tel ) ,
	CONSTRAINT preinscription_id_parcours_fkey FOREIGN KEY ( id_parcours ) REFERENCES "public".parcours( id ) ON DELETE CASCADE ON UPDATE CASCADE ,
	CONSTRAINT fk_preinscription_option FOREIGN KEY ( id_option ) REFERENCES "public"."option"( id ) ON DELETE CASCADE ON UPDATE CASCADE 
 );

ALTER TABLE "public".preinscription ADD CONSTRAINT preinscription_email_check CHECK ( email ~ '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$'::text );

