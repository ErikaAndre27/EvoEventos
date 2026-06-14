# Evo Eventos Frontend

Este es el frontend el proyecto EvoEventos

## Instalación

## Dependencias
Para instalar las dependencias en la raiz del proyecto correl el comando

```
npm install
```
## Correr el proyecto
Una vez instaladas las dependencias correr el proyecto utilizando el comando

```
npm run dev
```

## Instalar imagen en docker
```
docker build -t evo_eventos_front -f dockerfile.dev .
```


## Correr en docker

```
windows:
docker run -d --name evo_eventos_container -p 5173:5173 -v ${pwd}:/app -v /app/node_modules -w /app evo_eventos_front

sistemas UNIX based
docker run -d --name evo_eventos_container -p 5173:5173 -v $(pwd):/app -v /app/node_modules -w /app evo_eventos_front
```