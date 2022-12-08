package com.example.t3_spring_dbserver.repository;

import com.example.t3_spring_dbserver.entity.Inventory;
import com.example.t3_spring_dbserver.entity.SockCard;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.Optional;

@Repository
public interface ISocksInventoryRepository extends JpaRepository<Inventory, Long> {
//    @Query( value = "SELECT *  FROM sep_db.inventory i WHERE i.pc_id = :cardId",
//            nativeQuery = true)
//    List<Inventory> getByCardId(@Param("cardId") int cardId);

    @Query("SELECT i  FROM Inventory i WHERE i.sockCard = :cardId")
    List<Inventory> getByCardId(@Param("cardId") int cardId);

    @Transactional
    @Modifying
    @Query("DELETE FROM Inventory i WHERE i.sockCard.id = :id")
    void deleteByCardId(@Param("id") long id);
}
