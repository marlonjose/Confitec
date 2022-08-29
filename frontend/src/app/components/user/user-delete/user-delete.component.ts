import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Escolaridade } from '../escolaridade-enum';
import { Usuario } from '../user-model';
import { UsuarioService } from '../user.service';

@Component({
  selector: 'app-user-delete',
  templateUrl: './user-delete.component.html',
  styleUrls: ['./user-delete.component.css']
})
export class UserDeleteComponent implements OnInit {

  escolaridades = [
    { name: 'Infantil', value: 1 }, 
    { name: 'Fundamental', value: 2 }, 
    { name: 'médio', value: 3 }, 
    { name: 'Superior', value: 4 } 
  ];

  user: Usuario;

  constructor(private usuarioService: UsuarioService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')
    this.usuarioService.readById(id).subscribe(userResponse => {
      this.user = userResponse
      this.user.dataNascimento = new Date(this.user.dataNascimento)
      this.user.escolaridadeNome = Escolaridade[userResponse.escolaridade]
    })
  }

  deleteUser():void {
    debugger;
    this.usuarioService.delete(this.user.id).subscribe(()=>{
      this.usuarioService.showMensage('Usuário removido com sucesso')
      this.router.navigate(['/users']);
    });
  }

  cancel(): void {
    this.router.navigate(['/users'])
  }

}
