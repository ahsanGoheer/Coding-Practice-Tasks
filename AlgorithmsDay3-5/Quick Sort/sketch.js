let values=[];
let w=5;
let states=[];
function setup()
{
  createCanvas(windowWidth,windowHeight);
  values = new Array(floor(width/w));
  
  for(var i=0;i<values.length;i++)
  {
      values[i]=random(height);
      states[i]=-1;
  }
  quickSort(values,0,values.length-1);

}

async function quickSort(array,start,end)
{
 if(start>=end) return;
 let index= await partition(array,start,end);
states[index]=-1;
 await Promise.all([quickSort(array,start,index-1),quickSort(array,index+1,end)]);
}

async function partition(array,start,end)
{
    for (let i = start; i < end; i++) {
        states[i] = 1;
      }
    let pivotIndex=start;
    let pivotValue=array[end];
    states[pivotIndex]=0;
    for(var i=start;i<end;i++)
    {
        if(array[i]<pivotValue)
        {
            await swap(array,pivotIndex,i);
            states[pivotIndex]=-1;
            pivotIndex++;
            states[pivotIndex]=0;
        }

    }
    await swap(array,pivotIndex,end);
    for(var i=start;i<end;i++)
    {
        if(pivotIndex!=i)
            {states[i]=-1;}
    }
    return pivotIndex;
}
async function swap(array,a,b)
{
    await sleep(50);
    var temp=array[a]
    array[a]=array[b]
    array[b]=temp
}
function draw()
{
    let c=color('#581845')
    background(c);
    for(var i=0;i<values.length;i++)
    {
        stroke(255);
        if(states[i]==0)
        {
            fill('#DAF7A6');
        }
        else if(states[i]==1)
        {
            fill('orange');
        }
        else
        {
            fill('#2E4053');
        }
        rect(i * w, height - values[i], w, values[i]);
    }


}
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }
  