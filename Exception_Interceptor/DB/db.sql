-- Создание таблицы отдела
CREATE TABLE departments (
    department_id SERIAL PRIMARY KEY, -- уникальный идентификатор отдела
    name VARCHAR(255) NOT NULL,        -- название отдела
    manager_name VARCHAR(255)          -- имя менеджера отдела
);

-- Создание таблицы сотрудников
CREATE TABLE employees (
    employee_id SERIAL PRIMARY KEY,  -- уникальный идентификатор сотрудника
    first_name VARCHAR(255) NOT NULL,  -- имя сотрудника
    last_name VARCHAR(255) NOT NULL,   -- фамилия сотрудника
    department_id INTEGER REFERENCES departments(department_id) -- идентификатор отдела
);



CREATE TABLE My_Line_Records
(
    Id SERIAL PRIMARY KEY,
    Line TEXT,
    Created_At TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Duplicate_Count INTEGER
);