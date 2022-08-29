import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Escolaridade } from '../escolaridade-enum';
import { Usuario } from '../user-model';
import { UsuarioService } from '../user.service';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent implements OnInit {

  escolaridades = [
    { name: 'Infantil', value: 1 }, 
    { name: 'Fundamental', value: 2 }, 
    { name: 'médio', value: 3 }, 
    { name: 'Superior', value: 4 } 
  ];

  user: Usuario = {
    nome: '',
    sobrenome: '',
    email: '',
    escolaridade: null,
    dataNascimento: new Date()
  }

  constructor(private usuarioService: UsuarioService, private router: Router) { }

  ngOnInit(): void {
  }

  createUser(): void {
    this.user.escolaridade = Number(this.user.escolaridade)
    this.usuarioService.create(this.user).subscribe(() => {
      this.usuarioService.showMensage('Usuário registrado com sucesso')
      this.router.navigate(['/users'])
    })
  }

  cancel(): void {
    this.router.navigate(['/users'])
  }

}
