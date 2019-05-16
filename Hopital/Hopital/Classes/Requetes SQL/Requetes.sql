select m.Id, m.Nom, m.Prenom, s.Specialite, serv.Nom  from medecin as m  
inner join Spec as s on m.CodeSpecialite = s.CodeSpec
inner join Service as serv on m.IdService = serv.Id