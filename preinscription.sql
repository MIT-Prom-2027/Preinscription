CREATE SCHEMA IF NOT EXISTS "public";

CREATE SEQUENCE "public".faculte_id_seq AS integer START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".mention_id_seq AS integer START WITH 1 INCREMENT BY 1;

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
	CONSTRAINT mention_id_faculte_fkey FOREIGN KEY ( id_faculte ) REFERENCES "public".faculte( id )   
 );

CREATE  TABLE "public".parcours ( 
	id                   serial  NOT NULL  ,
	id_mention           integer    ,
	nom_parcours         varchar(100)    ,
	CONSTRAINT parcours_pkey PRIMARY KEY ( id ),
	CONSTRAINT parcours_id_mention_fkey FOREIGN KEY ( id_mention ) REFERENCES "public".mention( id )   
 );

CREATE  TABLE "public".preinscription ( 
	num_bacc             integer  NOT NULL  ,
	annee_bacc           integer  NOT NULL  ,
	email                text    ,
	tel                  varchar(100)    ,
	recu_bancaire        varchar(100)  NOT NULL  ,
	date_preinscription  date DEFAULT CURRENT_DATE   ,
	id_parcours          integer    ,
	chemin_preuve_paiement text    ,
	est_valide           boolean DEFAULT false   ,
	CONSTRAINT preinscription_pkey PRIMARY KEY ( num_bacc, annee_bacc ),
	CONSTRAINT preinscription_tel_key UNIQUE ( tel ) ,
	CONSTRAINT preinscription_id_parcours_fkey FOREIGN KEY ( id_parcours ) REFERENCES "public".parcours( id )   
 );

ALTER TABLE "public".preinscription ADD CONSTRAINT preinscription_email_check CHECK ( email ~ '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$'::text );

