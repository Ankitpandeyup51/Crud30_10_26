create database StudentManagementCrud2;
use StudentManagementCrud2;


CREATE TABLE Student (
    Id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    phone VARCHAR(20),
    dob DATE,
    gender VARCHAR(10),
    password VARCHAR(100) NOT NULL,
    address VARCHAR(255)
);

select * from student;
