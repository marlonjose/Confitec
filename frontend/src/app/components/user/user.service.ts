import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { catchError, map } from 'rxjs/operators';
import { Usuario } from './user-model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  endpoint = "https://localhost:7247/v1/usuario"

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  showMensage(msg: string, isError: boolean = false): void {
    this.snackBar.open(msg, "x", {
      duration: 3000,
      horizontalPosition: "center",
      verticalPosition: "top",
      panelClass: isError ? ['msg-error'] : ['msg-success']
    });
  }

  create(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.endpoint, usuario).pipe(
      map(obj => obj),
      catchError(e => this.erroHandler(e))
    )
  }

  read(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.endpoint).pipe(
      map(obj => obj),
      catchError(e => this.erroHandler(e))
    )
  }

  readById(id: number): Observable<Usuario> {
    const url = `${this.endpoint}/${id}`
    return this.http.get<Usuario>(url).pipe(
      map(obj => obj),
      catchError(e => this.erroHandler(e))
    )
  }

  update(usuario: Usuario): Observable<Usuario> {
    const url = `${this.endpoint}/${usuario.id}`
    return this.http.put<Usuario>(url, usuario).pipe(
      map(obj => obj),
      catchError(e => this.erroHandler(e))
    )
  }

  delete(id: number): Observable<Usuario> {
    debugger;
    const url = `${this.endpoint}/${id}`
    return this.http.delete<Usuario>(url).pipe(
      map(obj => obj),
      catchError(e => this.erroHandler(e))
    )
  }

  erroHandler(e : any): Observable<any>{
    for(const [key, value] of Object.entries(e.error.errors)) {
      this.showMensage(value[0], true)
      break;
    }
    return EMPTY
  }
}
