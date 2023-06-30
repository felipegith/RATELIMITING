<h1 align='center'>ASP NET CORE: Rate Limiting</h1>
<p align='center'>Utilizando o middleware para trabalhar com limitação de taxas. Com isso é possível controlar a quantidade de requisições que um endpoint recebe em determinado intervalo.</p>
<p align='center'>Neste exemplo podemos ver alguns tipos de policy para os limiter.</p>

    fixed window: Ele limita as requisições de acordo com uma janela de tempo fixa e número de requisições. Imagine um cenário onde nós temos um endpoint que recebeu 10 requisições. Neste método nós poderiamos configurar para quando esse endpoint
    receber 10 requisiçoes em um intervalo de tempo, ele aguarde uma janela de tempo para continuar com as outras requisições.

    sliding window: Esse método é parecido com o fixed, porém a sua diferença é que ele adicionar segmento a cada janela. Imagine que nós temos uma janela de uma hora e essa janela é divida em dois segmentos de 30 minutos. Ou seja, a cada 30 minutos a minha janela irá deslizar para o próximo segmento.
    Para deixar mais claro, imagine que nós configuramos um limite de 10 requsições, nos primeiros 30 minutos nós recebemos cinco requisições, então essas cinco requisições vao para o segmento atual. Nos próximos 30 minutos, as outras 5 requisições serão realizadas.

    concurrency window: Esse método limita quantas requisições podem acessar um recurso. Imagine um cenário onde configuramos esse método para poder acessar um endpoint no máximo 10 vezes. Quando eu
    tentar realizar a 11º requisição, ele não deixará. Para a requisição seja feita, uma das últimas 10 requisições precisam ter sido finalizadas, com isso, abre espaço para uma nova requisição

    token bucket limit: Esse método um número fixo de tokens( ou requisições )é adicionado de acordo com uma taxa. Ou seja, imagine que temos um cenário onde temos um bucket que permite somente 20 requisições em um endpoint,
    quando o usuário fizer uma requisição, esse bucket que tem o limite de 20 requisições será reduzido para 19, com isso, a requisição será realizada com sucesso. Quando esse número de 20 requisições chegar ao
    seu limite, as próximas requisições serão negadas pela aplicação.

</ul>
