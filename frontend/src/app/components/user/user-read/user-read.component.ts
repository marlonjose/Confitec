import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Escolaridade } from '../escolaridade-enum';
import { Usuario } from '../user-model';
import { UsuarioService } from '../user.service';

@Component({
  selector: 'app-user-read',
  templateUrl: './user-read.component.html',
  styleUrls: ['./user-read.component.css']
})
export class UserReadComponent implements OnInit {

  usuarios: Usuario[]
  displayedColumns = ['id', 'nome', 'sobrenome', 'email', 'dataNascimento', 'escolaridade', 'action']

  constructor(private usuarioService: UsuarioService, private router: Router) { 
    this.usuarioService.read().subscribe(users => {
      users.map(user => {
        user.escolaridadeNome = Escolaridade[user.escolaridade]
        console.log(user)
      })
      console.log(users)
      this.usuarios = users
      console.log(users);
    })
  }

  ngOnInit(): void {
  }

}
