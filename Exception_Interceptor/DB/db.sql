-- �������� ������� ������
CREATE TABLE departments (
    department_id SERIAL PRIMARY KEY, -- ���������� ������������� ������
    name VARCHAR(255) NOT NULL,        -- �������� ������
    manager_name VARCHAR(255)          -- ��� ��������� ������
);

-- �������� ������� �����������
CREATE TABLE employees (
    employee_id SERIAL PRIMARY KEY,  -- ���������� ������������� ����������
    first_name VARCHAR(255) NOT NULL,  -- ��� ����������
    last_name VARCHAR(255) NOT NULL,   -- ������� ����������
    department_id INTEGER REFERENCES departments(department_id) -- ������������� ������
);



CREATE TABLE My_Line_Records
(
    Id SERIAL PRIMARY KEY,
    Line TEXT,
    Created_At TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Duplicate_Count INTEGER
);