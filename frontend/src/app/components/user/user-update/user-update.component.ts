import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Escolaridade } from '../escolaridade-enum';
import { Usuario } from '../user-model';
import { UsuarioService } from '../user.service';

@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html',
  styleUrls: ['./user-update.component.css']
})
export class UserUpdateComponent implements OnInit {

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

  updateUser():void {
    this.usuarioService.update(this.user).subscribe(()=>{
      this.usuarioService.showMensage('Usuário atualizado com sucesso')
      this.router.navigate(['/users']);
    });
  }

  cancel(): void {
    this.router.navigate(['/users'])
  }

}
