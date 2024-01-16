import { Component, OnInit, ViewChild } from '@angular/core';

import{PlainMarker} from '../markers-page/markers-page.component'

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MostrarApartamentoService } from '../../../auth/pagesAuth/services/mostrarApartamento.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DetalleimagenComponent } from '../detalleimagen/detalleimagen.component';





@Component({
  templateUrl: './properties-page.component.html',
  styleUrls: ['./properties-page.component.css']
})
export class PropertiesPageComponent implements OnInit {
//

public columsToDisplay=['Apartamento','Descripcion','Servicios','Condiciones','Imagen'];
public datasource:any=new MatTableDataSource();
public apartamentos!:any[];

      @ViewChild(MatPaginator) paginator!:MatPaginator;

      constructor(private mostrarApartamentoServicio:MostrarApartamentoService,public dialog:MatDialog,
        public router:Router){

      }

    ngOnInit(): void {

      this.getDataApartamentos();

    }

    getDataApartamentos(){
      this.mostrarApartamentoServicio.traerTodosApartamentos().subscribe((response:any)=>{
        console.log(response);
        this.apartamentos=response;
        this.datasource.data=this.apartamentos;
        this.datasource.paginator=this.paginator;

      })
    }


    applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
      this.datasource.filter = filterValue.trim().toLowerCase();
    }

    openDialogApartamentos(apartamento:any){
    const dialogRef=this.dialog.open(DetalleimagenComponent,{
    width:'800px',
    height:'600px',
    data:apartamento
    });
    dialogRef.afterClosed().subscribe(result=>{
      console.log('OK')
    })

    }

//


}
