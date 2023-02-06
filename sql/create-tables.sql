CREATE TABLE "developer" (
	"email"	TEXT NOT NULL,
	"first_name"	TEXT NOT NULL,
	"last_name"	TEXT NOT NULL,
	"full_name"	REAL NOT NULL,
	"age"	INTEGER NOT NULL,
	"worked_hour"	INTEGER,
	"salary_by_hours"	INTEGER NOT NULL,
	"developer_type_id"	INTEGER NOT NULL,
	PRIMARY KEY("email")
);