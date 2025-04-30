const port = process.env.RAILWAY_PORT || process.env.PORT || 5200;

app.listen(port, () => {
  console.log(`Servidor rodando na porta ${port}`);
}); 