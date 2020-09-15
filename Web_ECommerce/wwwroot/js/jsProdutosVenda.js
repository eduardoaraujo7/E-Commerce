

var ObjetoVenda = new Object();

ObjetoVenda.AdicionarCarrinho = function (idProduto) {

    var nome = $("#nome_" + idProduto).val();
    var qtd = $("#qtd_" + idProduto).val();

    $.ajax({
        type: 'POST',
        url: "/api/AdicionarProdutoCarrinho",
        dataType: "JSON",
        cache: false,
        async: true,
        data: {
            "id": idProduto, "nome": nome, "qtd": qtd
        },
        success: function (data) {

            if (data.sucesso) {
                // 1 alert-success// 2 alert-warning// 3 alert-danger
                ObjetoAlerta.AlertaTela(1, "Produto adicionado no carrinho!");
            }
            else {
                // 1 alert-success// 2 alert-warning// 3 alert-danger
                ObjetoAlerta.AlertaTela(2, "Necessario efetuar login!");
            }
        }
    });
}

ObjetoVenda.CarregaProdutos = function () {

    $.ajax({
        type: 'GET',
        url: "/api/ListarProdutoComEstoque",
        dataType: "JSON",
        cache: false,
        async: true,
        success: function (data) {

            var htmlConteudo = "";

            data.forEach(function (Entitie) {

                htmlConteudo += " <div class='col-xs-12 col-sm-4 col-md-4 col-lg-4'>";

                var idNome = "nome_" + Entitie.id;
                var idQtd = "qtd_" + Entitie.id;

                htmlConteudo += "</br><label id='" + idNome + "' > " + Entitie.nome + "</label></br>";

                htmlConteudo += "<label> Descricao :  " + Entitie.descricao + "</label></br>";
                

                if (Entitie.url != null && Entitie.url != "" && Entitie.url != undefined) {

                    htmlConteudo += "<img width='200' heigth='100' src='" + Entitie.url + "'/></br>";
                }

                htmlConteudo += "<label> Valor: " + Entitie.valor + "</label></br>";

                htmlConteudo += "Quantidade : <input type'number' value='1' id='" + idQtd + "'>";

                htmlConteudo += "<input type='button' onclick='ObjetoVenda.AdicionarCarrinho(" + Entitie.id + ")' value ='Comprar'></br> ";

                htmlConteudo += " </div>";

            });

            $("#DivVenda").html(htmlConteudo);
        }
    });
}

ObjetoVenda.CarregaQtdCarrinho = function () {

    $("#qtdCarrinho").text("(0)");

    $.ajax({
        type: 'GET',
        url: "/api/QtdProdutoCarrinho",
        dataType: "JSON",
        cache: false,
        async: true,
        success: function (data) {

            if (data.sucesso) {
                $("#qtdCarrinho").text("(" + data.qtd + ")");
            }
        }
    });

    setTimeout(ObjetoVenda.CarregaQtdCarrinho, 1000); 
}

$(function () {
    ObjetoVenda.CarregaProdutos();
    ObjetoVenda.CarregaQtdCarrinho();
});