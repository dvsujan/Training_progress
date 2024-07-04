select e.e_name, e.age, e.phone, d.d_name, s.salary
from employee e
join department d ON e.d_id = d.d_id
join salary s ON e.e_id = s.e_id