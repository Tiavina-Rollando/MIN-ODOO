CREATE TABLE `employes` (
    `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nom` VARCHAR(255) NOT NULL,
    `prenom` VARCHAR(255) NOT NULL,
    `d_naissance` DATE NULL,
    `adresse` VARCHAR(255) NOT NULL,
    `matricule` VARCHAR(255) NULL,
    `mdp` VARCHAR(255) NULL,
    `email` VARCHAR(255) NULL,
    `tel` VARCHAR(255) NULL,
    `empreint` BLOB NULL,
    `photo` BLOB NULL,
    `sexe` BOOLEAN NOT NULL,
    `d_integration` DATE NULL,
    `id_nation` INT UNSIGNED NULL,
    `id_role` SMALLINT UNSIGNED NULL,
    `id_post` INT UNSIGNED NULL,
    FOREIGN KEY (`id_nation`) REFERENCES `nations` (`id`),
    FOREIGN KEY (`id_role`) REFERENCES `roles` (`id`),
    FOREIGN KEY (`id_post`) REFERENCES `postes` (`id`)
);

CREATE TABLE `departements` (
    `id` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nom` VARCHAR(255) NOT NULL,
    `poste_vaccant` INT NULL
);

CREATE TABLE `conges` (
    `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `id_emp` BIGINT UNSIGNED NOT NULL,
    `id_man` BIGINT UNSIGNED NOT NULL,
    `d_deb` DATE NOT NULL,
    `d_fin` DATE NOT NULL,
    `id_dm` BIGINT UNSIGNED NULL,
    FOREIGN KEY (`id_emp`) REFERENCES `employes` (`id`),
    FOREIGN KEY (`id_man`) REFERENCES `employes` (`id`),
    FOREIGN KEY (`id_dm`) REFERENCES `dem_conges` (`id`)
);

CREATE TABLE `pointages` (
    `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `date` DATE NOT NULL,
    `id_emp` BIGINT UNSIGNED NOT NULL,
    `h_arrivee` TIME NOT NULL,
    FOREIGN KEY (`id_emp`) REFERENCES `employes` (`id`)
);

CREATE TABLE `dem_conges` (
    `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `id_emp` BIGINT UNSIGNED NOT NULL,
    `d_dem` DATE NULL,
    `d_deb` DATE NULL,
    `d_fin` DATE NULL,
    `pretexte` VARCHAR(255) NULL,
    `statut` BOOLEAN NULL,
    FOREIGN KEY (`id_emp`) REFERENCES `employes` (`id`)
);

CREATE TABLE `taches` (
    `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nom` VARCHAR(255) NOT NULL,
    `delais` TIME NULL,
    `support` BLOB NULL,
    `statut` BOOLEAN NULL,
    `d_rendu` DATE NULL
);

CREATE TABLE `feedbacks` (
    `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `tenue` BOOLEAN NULL,
    `comportement` BOOLEAN NULL,
    `id_man` BIGINT UNSIGNED NULL,
    `id_emp` BIGINT UNSIGNED NULL,
    `justificatif` VARCHAR(255) NULL,
    FOREIGN KEY (`id_man`) REFERENCES `employes` (`id`),
    FOREIGN KEY (`id_emp`) REFERENCES `employes` (`id`)
);

CREATE TABLE `scores` (
    `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `valeur` INT NOT NULL,
    `id_emp` BIGINT UNSIGNED NOT NULL,
    `mois` VARCHAR(255) NOT NULL,
    FOREIGN KEY (`id_emp`) REFERENCES `employes` (`id`)
);

CREATE TABLE `nations` (
    `id` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nom` VARCHAR(255) NOT NULL,
    `peuple` VARCHAR(255) NOT NULL,
    `drapeau` BLOB NULL
);

CREATE TABLE `repartitions_taches` (
    `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `id_tache` BIGINT UNSIGNED NOT NULL,
    `id_emp` BIGINT UNSIGNED NULL,
    `d_deb` DATE NOT NULL,
    `d_fin` DATE NOT NULL,
    FOREIGN KEY (`id_tache`) REFERENCES `taches` (`id`),
    FOREIGN KEY (`id_emp`) REFERENCES `employes` (`id`)
);

CREATE TABLE `roles` (
    `id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `nom` VARCHAR(255) NOT NULL
);

CREATE TABLE `postes` (
    `id` INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `statut` BOOLEAN NULL,
    `nom` VARCHAR(255) NOT NULL,
    `id_dep` INT UNSIGNED NULL,
    FOREIGN KEY (`id_dep`) REFERENCES `departements` (`id`)
);

-- Insertion de données
INSERT INTO `nations` (nom, peuple) VALUES
('Madagascar','Malgache'), 
('Maurice','Mauricien'), 
('Russie','Russe'), 
('France','Français'), 
('Canada','Canadien'),
('Allemagne','Allemand'), 
('Espagne','Espagnol'), 
('Angleterre','Anglais'), 
('Comore','Comorien'), 
('Sénégal','Sénégalais'),
('Congo','Congolais'), 
('Egypte','Egyptien'), 
('Chine','Chinois'), 
('Corée','Coréen'), 
('Japon','Japonais');

INSERT INTO `roles` (nom) VALUES
('Administrateur'), 
('Manager'), 
('Salarié');

INSERT INTO `departements` (nom) VALUES
('Direction Générale'),
('Ressources Humaines'),
('Comptabilité et Finance'),
('Informatique et Systèmes d’Information'),
('Marketing et Communication'),
('Commercial et Ventes'),
('Production et Opérations'),
('Logistique et Approvisionnement'),
('Juridique et Conformité'),
('Recherche et Développement'),
('Qualité, Hygiène, Sécurité et Environnement'),
('Service Client et Support');

INSERT INTO `postes` (nom, id_dep) VALUES
('Directeur général', 1), 
('Responsable RH', 2), 
('Chargé de recrutement', 2),
('Comptable', 3), 
('Directeur financier', 3), 
('Administrateur réseau', 4),
('Développeur', 4), 
('Community Manager', 5), 
('Responsable marketing', 6),
('Technicien de maintenance', 7), 
('Responsable production', 7),
('Gestionnaire d’entrepôt', 8), 
('Responsable logistique', 8),
('Juriste', 9), 
('Responsable conformité', 9), 
('Ingénieur R&D', 10),
('Auditeur qualité', 10), 
('Responsable service client', 12);

INSERT INTO `employes` (nom, prenom, d_naissance, adresse, sexe, id_nation, id_role, id_post) VALUES
('ANDRIAMANANTSOA', 'Tiavina Rollando', '2001-02-10', 'Ambohimirary', true, 1, 3, 4),
('RAKOTOMANGA', 'Harijaona', '2002-04-10', 'Mahamasina', true, 1, 3, 7), 
('RANDRIANJAFIENIARIVO', 'Tojo Fandresena', '2003-02-27', 'Antsobolo', true, 1, 3, 6), 
('RAFALIMANANA', 'Minosoa Mampionona', '2004-10-10', 'Ambohimangakely', false, 1, 2, 2), 
('DANIE', 'Anand', '2002-08-18', 'Annkorondrano', false, 1, 2, 8), 
('RAHELIMALALA', 'Anja Nasandratra', '2005-03-21', 'Analamahitsy', false, 1, 3, 18);
