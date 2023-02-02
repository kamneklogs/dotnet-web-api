CREATE TABLE public.developer
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY,
    first_name character varying,
    last_name character varying,
    full_name character varying ,
    age integer,
    worked_hours integer,
    developer_type_id integer,
    email character varying,
    PRIMARY KEY (id)
);